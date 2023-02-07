using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private readonly IConfiguration _configuration;

        public UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //cria user admin
            CustomIdentityUser admin = new CustomIdentityUser
            { 
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "wilsonbrandaocosta@gmail.com",
                NormalizedEmail = "WILSONBRANDAOCOSTA@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("admininfo:password"));

            builder.Entity<CustomIdentityUser>().HasData(admin);

            //cria role admin
            builder.Entity<IdentityRole<int>>().HasData
                (
                    new IdentityRole<int>
                    {
                        Id = 99999,
                        Name = "admin",
                        NormalizedName = "ADMIN"
                    }
                );

            //cria role admin
            builder.Entity<IdentityRole<int>>().HasData
                (
                    new IdentityRole<int>
                    {
                        Id = 99997,
                        Name = "regular",
                        NormalizedName = "REGULAR"
                    }
                );

            //atribui role ao user admin
            builder.Entity<IdentityUserRole<int>>().HasData
                (
                    new IdentityUserRole<int>
                    {
                        RoleId = 99999,
                        UserId = 99999
                    }
                );
        }
    }
}
