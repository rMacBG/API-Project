using API_Models.Models;
using Microsoft.AspNetCore.Identity;

namespace API_Project.Extensions
{
    public static class IdentityExtension
    {
        public static async Task SeedRolesAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            if (roleManager.Roles.Any())
            {
                return;
            }
            var adminRole = CreateRole("Admin");
            var userRole = CreateRole("User");
            await roleManager.CreateAsync(adminRole);
            await roleManager.CreateAsync(userRole);

        }
        public static async Task SeedUsersAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            if (userManager.Users.Any())
            {
                return;
            }
            var admin = CreateUser("administrator@admin.com");
            await userManager.CreateAsync(admin, "Administrator");
            await userManager.AddToRoleAsync(admin, "Admin");

        }
        private static Role CreateRole(string name)
            => new Role
            {
                Name = name,
                NormalizedName = name.ToUpper(),
            };
        private static User CreateUser(string email, params string[] roles)
            => new User
            {
                UserName = email,
                Email = email,
            };
    }
}
