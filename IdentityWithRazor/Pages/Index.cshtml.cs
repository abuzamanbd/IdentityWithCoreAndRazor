using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IdentityWithRazor.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Services.Services;
using ServiceStack.Auth;

namespace IdentityWithRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserInformationService _userInformationService;

        public IndexModel(ILogger<IndexModel> logger, IUserInformationService userInformationService)
        {
            _logger = logger;
            _userInformationService = userInformationService;
        }

        [BindProperty]
        public LoginModel.InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            //await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                //var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                var result = await _userInformationService.GetUser(Input.Email);
                if (result != null)
                {
                    //_logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                //}
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning("User account locked out.");
                //    return RedirectToPage("./Lockout");
                //}
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        //public virtual async Task<bool> CheckPasswordAsync(string user, string password)
        //{
        //    if (user == null)
        //    {
        //        return false;
        //    }

        //    var result = await VerifyPasswordAsync(passwordStore, user, password);
        //    if (result == PasswordVerificationResult.SuccessRehashNeeded)
        //    {
        //        await UpdatePasswordHash(passwordStore, user, password, validatePassword: false);
        //        await UpdateUserAsync(user);
        //    }

        //    var success = result != PasswordVerificationResult.Failed;
        //    if (!success)
        //    {
        //        Logger.LogWarning(0, "Invalid password for user.");
        //    }
        //    return success;
        //}

        //protected virtual async Task<PasswordVerificationResult> VerifyPasswordAsync(IUserPasswordStore<TUser> store, TUser user, string password)
        //{
        //    var hash = await store.GetPasswordHashAsync(user, CancellationToken);
        //    if (hash == null)
        //    {
        //        return PasswordVerificationResult.Failed;
        //    }
        //    return PasswordHasher.VerifyHashedPassword(user, hash, password);
        //}

        //public virtual PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        //{
        //    if (hashedPassword == null)
        //    {
        //        throw new ArgumentNullException(nameof(hashedPassword));
        //    }
        //    if (providedPassword == null)
        //    {
        //        throw new ArgumentNullException(nameof(providedPassword));
        //    }

        //    byte[] decodedHashedPassword = Convert.FromBase64String(hashedPassword);

        //    // read the format marker from the hashed password
        //    if (decodedHashedPassword.Length == 0)
        //    {
        //        return PasswordVerificationResult.Failed;
        //    }
        //    switch (decodedHashedPassword[0])
        //    {
        //        case 0x00:
        //            if (VerifyHashedPasswordV2(decodedHashedPassword, providedPassword))
        //            {
        //                // This is an old password hash format - the caller needs to rehash if we're not running in an older compat mode.
        //                return (_compatibilityMode == PasswordHasherCompatibilityMode.IdentityV3)
        //                    ? PasswordVerificationResult.SuccessRehashNeeded
        //                    : PasswordVerificationResult.Success;
        //            }
        //            else
        //            {
        //                return PasswordVerificationResult.Failed;
        //            }

        //        case 0x01:
        //            int embeddedIterCount;
        //            if (VerifyHashedPasswordV3(decodedHashedPassword, providedPassword, out embeddedIterCount))
        //            {
        //                // If this hasher was configured with a higher iteration count, change the entry now.
        //                return (embeddedIterCount < _iterCount)
        //                    ? PasswordVerificationResult.SuccessRehashNeeded
        //                    : PasswordVerificationResult.Success;
        //            }
        //            else
        //            {
        //                return PasswordVerificationResult.Failed;
        //            }

        //        default:
        //            return PasswordVerificationResult.Failed; // unknown format marker
        //    }
        //}

    }
}
