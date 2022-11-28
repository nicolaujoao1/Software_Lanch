using Microsoft.AspNetCore.Identity;

namespace Software_Lanch.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser>userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager; 
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Member").Result)
            {
                var role = new IdentityRole { Name = "Member", NormalizedName = "MEMBER" };
                var result= _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
                var result= _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario@gmail.com").Result is null)
            {
                var user = new IdentityUser
                {
                    UserName= "Usuario",
                    Email= "usuario@gmail.com",
                    NormalizedUserName="USUARIO",
                    NormalizedEmail="USUARIO@GMAIL.COM",
                    EmailConfirmed=true,
                    LockoutEnabled=false,
                    SecurityStamp=Guid.NewGuid().ToString()
                };
                var result= _userManager.CreateAsync(user,"Usuario#321").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
            if (_userManager.FindByEmailAsync("admin@gmail.com").Result is null)
            {
                var user = new IdentityUser
                {
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var result = _userManager.CreateAsync(user, "Admin#321").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
