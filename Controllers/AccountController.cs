using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MaturaToBzdura.Controllers;
using MaturaToBzdura.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using wiKorki.Data.Static;
using wiKorki.Data.ViewModels;


namespace wikorki.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Login() => View(new LoginVM());
      
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["Error"] = "Nieprawidłowy e-mail lub hasło. Proszę spróbuj ponownie!";
                    return View(loginVM);
                }
            }
            TempData["Error"] = "Nieprawidłowy e-mail lub hasło. Proszę spróbuj ponownie!";
            return View(loginVM);

        }

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
           

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Ten adres e-mail jest już zajęty!";
               
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                return View("RegisterCompleted");
            }
            else return View("RegisterFailed");
        }

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                // If the user is not found, return a not found error
                return NotFound();
            }

            var model = new DeleteVM();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteVM model)
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                // If the user is not found, return a not found error
                return NotFound();
            }
            var hasher = new PasswordHasher<IdentityUser>();
            var hashedPassword = hasher.HashPassword(user, model.Password);

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, hashedPassword);


            if (!isPasswordValid)
            {
            
                return View(model);
            }

            // Delete the user
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                // If the deletion succeeded, sign the user out and redirect to the home page
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If the deletion failed, display an error message
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                // Return the Delete view with the error messages
                return View(model);
            }
        }





        public async Task<IActionResult> MyAccount()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = new MyAccountParentVM
            {
                Credentials= new ChangeCredentialsVM
                {
                    FullName = user.FullName,
                    UserName = user.UserName,
                    EmailAddress = user.Email
                },
            Password = new ChangePasswordVM()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeCredentials()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = new ChangeCredentialsVM
            {
                FullName = user.FullName,
                UserName = user.UserName,
                EmailAddress = user.Email
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeCredentials(MyAccountParentVM model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

             // Update the user's account details with the form inputs
                user.FullName = model.Credentials.FullName;
                user.UserName = model.Credentials.UserName;
                user.Email = model.Credentials.EmailAddress;

          
            // Save the updated user details to the database
            var result = await _userManager.UpdateAsync(user);
                TempData["ChangedCredentials"] = "Zmiany zostały zapisane.";

            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                TempData["ChangedCredentials"] = "Zmiany zostały zapisane.";
             
                return RedirectToAction("MyAccount");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                   
                }
                return View(model);
            }
        }

        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = new ChangePasswordVM { };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
            if (!isPasswordCorrect)
            {
                TempData["WrongPassword"] = "Nieprawidłowe aktualne hasło";
                return View(model);
            }

            var passwordChange = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!passwordChange.Succeeded)
            {
                foreach (var error in passwordChange.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
            TempData["ChangedPassword"] = "Zmiany zostały zapisane.";
            TempData["ChangedCredentials"] = "Hasło zostało zmienione pomyślnie.";
            return RedirectToAction("MyAccount");
        }




        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
