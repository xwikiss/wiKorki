using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using wiKorki.Data.Static;

namespace wikorki.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationbuilder)
        {
            using (var serviceScope = applicationbuilder.ApplicationServices.CreateScope())
            {
                //roles section
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //users section
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var adminUser = await userManager.FindByEmailAsync("admin@wikorki.com");
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = "admin@wikorki.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding!23");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                var appUser = await userManager.FindByEmailAsync("user@wikorki.com");
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = "user@wikorki.com",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding!23");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }



    }
}
