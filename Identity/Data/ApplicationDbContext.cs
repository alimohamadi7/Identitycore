﻿using Identity.Entity;
using Identity.Mapings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.AddCustomEntityMappings();
            //builder.Entity<User>(modelBuilder =>
            //{
            //    modelBuilder.ToTable("Users");
            //});


            //builder.Entity<Role>(modelBuilder =>
            //{
            //    modelBuilder.ToTable("Roles");
            //});

            //builder.Entity<UserClaim>(modelBuilder =>
            //{
            //    modelBuilder.ToTable("UserClaims");

            //    modelBuilder
            //        .HasOne(userClaim => userClaim.User)
            //        .WithMany(user => user.Claims)
            //        .HasForeignKey(userClaim => userClaim.UserId);
            //});


            //builder.Entity<UserRole>(modelBuilder =>
            //{
            //    modelBuilder.ToTable("UserRoles");

            //    modelBuilder
            //        .HasOne(userRole => userRole.User)
            //        .WithMany(user => user.Roles)
            //        .HasForeignKey(userRole => userRole.UserId);


            //    modelBuilder
            //        .HasOne(userRole => userRole.Role)
            //        .WithMany(role => role.Roles)
            //        .HasForeignKey(userRole => userRole.RoleId);
            //});

            //builder.Entity<UserLogin>(modelBuilder =>
            //{
            //    modelBuilder.ToTable("UserLogins");

            //    modelBuilder
            //        .HasOne(userLogin => userLogin.User)
            //        .WithMany(user => user.Logins)
            //        .HasForeignKey(userLogin => userLogin.UserId);
            //});

            builder.Entity<RoleClaim>(modelBuilder =>
            {
                modelBuilder.ToTable("RoleClaims");

                modelBuilder.HasOne(roleClaim => roleClaim.Role)
                    .WithMany(role => role.Claims)
                    .HasForeignKey(roleClaim => roleClaim.RoleId);
            });


            builder.Entity<UserToken>(modelBuilder =>
            {
                modelBuilder.ToTable("UserTokens");

                modelBuilder.HasOne(userToken => userToken.User)
                    .WithMany(user => user.Tokens)
                    .HasForeignKey(userToken => userToken.UserId);
            });
        }

    }
}
