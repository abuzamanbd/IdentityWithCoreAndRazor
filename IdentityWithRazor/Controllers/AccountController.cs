using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Services;
using Services.ViewModel;


namespace IdentityWithRazor.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserInformationService _userInformationService;

        public AccountController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }

        [HttpPost]
        public IActionResult Login(UserInfoViewModel userInfo, string returnUrl)
        {
            _userInformationService.GetUser(userInfo.Email);
            return null;
        }
    }
}
