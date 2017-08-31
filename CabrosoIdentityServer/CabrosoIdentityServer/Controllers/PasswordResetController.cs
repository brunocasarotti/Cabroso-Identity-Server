using CabrosoIdentityServer.Identity;
using CabrosoIdentityServer.Models;
using IdentityServer3.Core.Extensions;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CabrosoIdentityServer.Controllers
{
    public class PasswordResetController : Controller
    {
        UserManager userMgr;
        DpapiDataProtectionProvider provider;

        public PasswordResetController()
        {
            provider = new DpapiDataProtectionProvider(nameof(CabrosoIdentityServer));
            userMgr = new UserManager(new UserStore(new IdentityContext("name=AspId")))
            {
                UserTokenProvider = new DataProtectorTokenProvider<User>(provider.Create("PasswordReset"))
            };
        }

        [HttpGet]
        [Route("core/passwordReset")]
        public async Task<ActionResult> Index(string signin)
        {
            var ctx = Request.GetOwinContext();
            var signInMessage = ctx.Environment.GetSignInMessage(signin);
            if (signInMessage == null)
            {
                return View("Error");
            }

            //if (string.IsNullOrWhiteSpace(signInMessage.ClientId))
            //    throw new NotImplementedException("ClientId desconhecido");

            return View(nameof(Index), new PasswordRecovery());
        }

        [HttpPost]
        [Route("core/passwordReset")]
        public async Task<ActionResult> Index(PasswordRecovery model)
        {
            if (ModelState.IsValid)
            {
                var ctx = Request.GetOwinContext();
                var user = await userMgr.FindByEmailAsync(model.Email);

                if (user == null)
                    throw new NotImplementedException("Usuário não encontrado");

                if (!user.EmailConfirmed)
                    throw new NotImplementedException("Email do usuario nao confirmado");

                var token = await userMgr.GeneratePasswordResetTokenAsync(user.Id);
                var link = string.Format("<a href=\"https://localhost:44333/core/PasswordReset/NewPassword?code={0}&userid={1}\">Click here to reset your password</a>", HttpUtility.UrlEncode(token), user.Id);

                ViewBag.PasswordResetLink = link;

                await userMgr.SendEmailAsync(user.Id, "Password reset", link);
            }
            else
            {
                ViewBag.PasswordResetLink = null;
            }

            return View(nameof(Index), new PasswordRecovery());
        }

        [HttpGet]
        [Route("core/PasswordReset/NewPassword")]
        public async Task<ActionResult> NewPassword(string code, string userid)
        {
            //var teste = await userMgr.ResetPasswordAsync(userid, code, "123123");
            return View(nameof(NewPassword), new NewPassword());
        }
    }
}