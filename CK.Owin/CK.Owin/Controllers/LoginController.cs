using CK.Owin.Common.Constants;
using CK.Owin.Common.Extensions;
using CK.Owin.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CK.Owin
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string returnUrl = "")
        {
            var model = new LoginViewModel();
            model.ReturnUrl = returnUrl;
            return View(model);
        }
       
        [HttpPost]
        public ActionResult Submit(LoginViewModel model)
        {
            if (model.Email.Equals("test@gmail.com", StringComparison.OrdinalIgnoreCase)
                    && model.Password.Equals("123"))
            {
                var claimIdentity = new ClaimsIdentity(ApplicationConstant.AUTHENTICATION_TYPE);
                claimIdentity.AddClaims(new List<Claim> {
                        new Claim(ClaimTypes.Email, model.Email),
                        new Claim(ClaimTypes.NameIdentifier, model.Email),
                        new Claim(ClaimTypes.Name, model.Email)
                    });

                HttpContext.GetOwinContext().Authentication.SignIn(claimIdentity);
            }

            if (model.ReturnUrl.IsNotNullOrEmpty())
            {
                return Redirect(model.ReturnUrl);
            }
            return RedirectToAction("Index");
            
        }

        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;

            if (authenticationManager.User.Identity.IsAuthenticated)
            {
                authenticationManager.SignOut(ApplicationConstant.AUTHENTICATION_TYPE);
            }

            return RedirectToAction("Index","Home");
        }
    }
}