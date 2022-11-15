using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Software_Lanch.ViewModels;

namespace Software_Lanch.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public IActionResult Login(string returnUrl)=>View(new LoginViewModel { ReturnUrl=returnUrl});
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user is not null)
            {
                var result =await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    if(string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                        return RedirectToAction(nameof(Index), "Home");
                    else
                        return Redirect(loginViewModel.ReturnUrl);
                }
                    
            }
            ModelState.AddModelError("","Falha ao realizar o Login!!");
            return View(loginViewModel);
            
        }
        public IActionResult Register() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Register(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                //var role = new IdentityRole { Name="Admin"};
                var user = new IdentityUser { UserName = loginViewModel.UserName };
                var result = await _userManager.CreateAsync(user, loginViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login), "Account");
                }
                else
                {
                    ModelState.AddModelError("Registro", "Ocorreu falha ao registrar!!!");

                }
            }
            return View(loginViewModel); 
            
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
        
    }
}
