using Microsoft.AspNetCore.Identity;

namespace $safeprojectname$.Data
{
    // ----------------------------------------------------------------------------------
    // Only needed when initially seeding the DB 
    // ----------------------------------------------------------------------------------

    public static class DataContextExtensions
    {
        public static RoleManager<IdentityRole> RoleManager { get; set; }
        public static UserManager<IdentityUser> UserManager { get; set; }

        public static void EnsureSeeded(this DataContext context)
        {
            AddRoles(context);
            AddUsers(context);
        }

        private static void AddRoles(DataContext context)
        {
            if (RoleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult() == false)
            {
                RoleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            }

            if (RoleManager.RoleExistsAsync("Customer").GetAwaiter().GetResult() == false)
            {
                RoleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();
            }
        }

        private static void AddUsers(DataContext context)
        {
            if (UserManager.FindByEmailAsync("mc.admin@coorp.com").GetAwaiter().GetResult() == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "mc.admin",
                    Email = "mc.admin@coorp.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "AdminPassword1*").GetAwaiter().GetResult();
            }

            var admin = UserManager.FindByEmailAsync("mc.admin@coorp.com").GetAwaiter().GetResult();

            if (UserManager.IsInRoleAsync(admin, "Admin").GetAwaiter().GetResult() == false)
            {
                UserManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}