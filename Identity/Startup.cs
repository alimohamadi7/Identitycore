using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Data;
using Identity.DataProtection;
using Identity.Entity;
using Identity.filter;
using Identity.Services;
using Identity.Services.Identity;
using Identity.Services.Identity.Managers;
using Identity.Services.Identity.Stores;
using Identity.Services.Identity.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Filters;

namespace Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.ConsentCookie.Name = "Consent";
            });



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //use session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);//You can set Time   
                options.Cookie.IsEssential = true;
                options.CookieName = "session";

            });
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    connectionString: Configuration.GetConnectionString("DefaultConnection")
                );
            });

            //for one show message customize validator
            services.AddScoped<IUserValidator<User>, AppUserValidator>();
            services.AddScoped<UserValidator<User>, AppUserValidator>();
            services.AddScoped<IRoleValidator<Role>, AppRoleValidator>();
            services.AddScoped<RoleValidator<Role>, AppRoleValidator>();

            services.AddIdentity<User, Role>(option =>
            {    //encryption dta
                //option.Stores.ProtectPersonalData = true;
                option.User.RequireUniqueEmail = true;
                option.Password.RequiredLength = 3;
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.SignIn.RequireConfirmedEmail = true;
                //option.SignIn.RequireConfirmedPhoneNumber = true;
                option.Lockout.DefaultLockoutTimeSpan =TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 2;
                option.Lockout.AllowedForNewUsers = true;

            })
                 .AddUserStore<AppUserStore>()
                .AddRoleStore<AppRoleStore>()
                //.AddUserValidator<AppUserValidator>()
                //.AddRoleValidator<AppRoleValidator>()
                .AddUserManager<AppUserManager>()
                .AddRoleManager<AppRoleManager>()
                .AddSignInManager<AppSignInManager>()
                .AddErrorDescriber<AppErrorDescriber>()
                .AddClaimsPrincipalFactory<AppUserClaimsPrincipalFactory>()
                .AddDefaultTokenProviders();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<ISmsSender, SmsSender>();
            //encryption data
            //services.AddScoped<ILookupProtectorKeyRing, KeyRing>();

            //services.AddScoped<ILookupProtector, LookupProtector>();

            //services.AddScoped<IPersonalDataProtector, PersonalDataProtector>();
            // external login
            services.AddAuthentication()

                 .AddGoogle(options =>
                 {
                     options.ClientId = Configuration["GoogleAuth:ClientId"];
                     options.ClientSecret = Configuration["GoogleAuth:ClientSecret"];
                 });
            //policy based
            services.AddScoped<IAuthorizationHandler, Plan18AuthorizationHandler>();
            //dynamic permission policy based
            services.AddScoped<IAuthorizationHandler, DynamicPermissionHandler>();

            services.AddScoped<IDynamicPermissionService, DynamicPermissionService>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequiredAdminRoleAndManager", policy =>
                {
                    policy.RequireRole("Admin", "Manager");
                });

                options.AddPolicy("Plan1", policy =>
                {
                    policy.RequireClaim("UserPlan", "1");
                });

                options.AddPolicy("Plan18", policy =>
                {
                    policy.Requirements.Add(new Plan18Requirement("ali"));
                });
                //dynamic permission policy based
                options.AddPolicy(ConstantPolicies.DynamicPermission, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new DynamicPermissionRequirement());
                });
            });
            //for SecurityStamp
            services.Configure<SecurityStampValidatorOptions>(o =>
            o.ValidationInterval = TimeSpan.FromMinutes(1));
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "App.Cookie";
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/access-denied";
                options.LogoutPath = "/sign-out";
                options.ReturnUrlParameter = "returnTo";
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor httpContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
//            app.UseSecurityHeadersMiddleware(new SecurityHeadersBuilder()
//.AddDefaultSecurePolicy()
//.AddCustomHeader("X-My-Custom-Header", "So cool")
//);

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();//use session
            app.Use(async (context, next) =>
            {
                CookieOptions cookie = new CookieOptions();
                cookie.IsEssential = true;
                context.Response.Cookies.Append("testcookie", "true", cookie);
                context.Response.Headers.Add("X-Xss-Protection", "1");
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                context.Response.Headers.Add("server", "none");

                // context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add(
    "Content-Security-Policy",
    "default-src 'self'; " +
    "img-src 'self' myblobacc.blob.core.windows.net; " +
    "font-src 'self'; " +
    "style-src 'self'; " +
    "script-src 'self' 'nonce-KIBdfgEKjb34ueiw567bfkshbvfi4KhtIUE3IWF' " +
    " 'nonce-rewgljnOIBU3iu2btli4tbllwwe'; " +
    "frame-src 'self';" +
    "connect-src 'self';");

                await next();
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                   template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                   );
                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
