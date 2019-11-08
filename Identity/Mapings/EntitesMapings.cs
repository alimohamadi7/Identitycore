using Identity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Mapings
{
    public static class EntitesMapings
    {
        public static void AddCustomEntityMappings(this ModelBuilder modelBuilder)
        {




            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users");
                builder.Property(p => p.GeneratedKey).HasMaxLength(300);
                builder.Property(p => p.PasswordHash).HasMaxLength(300);
                builder.Property(p => p.SecurityStamp).HasMaxLength(200);
                builder.Property(p => p.ConcurrencyStamp).HasMaxLength(400);
                builder.Property(p => p.PhoneNumber).HasMaxLength(50);
            });


            modelBuilder.Entity<Role>(builder =>
            {
                builder.ToTable("Roles");
            });

            modelBuilder.Entity<UserClaim>(builder =>
            {
                builder.ToTable("UserClaims");

                builder
                    .HasOne(userClaim => userClaim.User)
                    .WithMany(user => user.Claims)
                    .HasForeignKey(userClaim => userClaim.UserId);
            });


            modelBuilder.Entity<UserRole>(builder =>
            {
                builder.ToTable("UserRoles");

                builder
                    .HasOne(userRole => userRole.User)
                    .WithMany(user => user.Roles)
                    .HasForeignKey(userRole => userRole.UserId);


                builder
                    .HasOne(userRole => userRole.Role)
                    .WithMany(role => role.Roles)
                    .HasForeignKey(userRole => userRole.RoleId);
            });

            modelBuilder.Entity<UserLogin>(builder =>
            {
                builder.ToTable("UserLogins");

                builder
                    .HasOne(userLogin => userLogin.User)
                    .WithMany(user => user.Logins)
                    .HasForeignKey(userLogin => userLogin.UserId);
            });

            modelBuilder.Entity<RoleClaim>(builder =>
            {
                builder.ToTable("RoleClaims");
                builder.Property(p => p.ClaimType).HasMaxLength(400);
                builder.Property(p => p.ClaimValue).HasMaxLength(400);
                builder.HasOne(roleClaim => roleClaim.Role)
                    .WithMany(role => role.Claims)
                    .HasForeignKey(roleClaim => roleClaim.RoleId);
            });


            modelBuilder.Entity<UserToken>(builder =>
            {
                builder.ToTable("UserTokens");

                builder.HasOne(userToken => userToken.User)
                    .WithMany(user => user.Tokens)
                    .HasForeignKey(userToken => userToken.UserId);
            });
        }

    }
}
