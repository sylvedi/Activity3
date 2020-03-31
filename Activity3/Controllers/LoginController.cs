using Activity3.Models;
using Activity3.Services.Business;
using Activity3.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Activity3.Controllers
{
    [CustomerAction]
    public class LoginController : Controller
    {
        // private static Logger logger = LogManager.GetLogger("myAppLoggerRules");

        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult DoLogin(UserModel user)
        {

            MyLogger1.GetInstance().Info("Entering LoginController.DoLogin()");
            MyLogger1.GetInstance().Info("Parameters are: {0}", new JavaScriptSerializer().Serialize(user));
            try
            {
                //validate the form post
                if (!ModelState.IsValid)
                {
                    return View("Login");
                }

                //Use the Security Service to Authenticate the User
                SecurityService service = new SecurityService();
                bool result = service.Authenticate(user);

                if (result)
                {
                    MyLogger1.GetInstance().Info("Exit LoginController.DoLogin() with login success");
                    return View("LoginSuccess", user);
                }
                else
                {
                    MyLogger1.GetInstance().Info("Exit LoginController.DoLogin() with login failing");
                    return View("LoginFailed");
                }
            }
            catch (Exception e)
            {
                MyLogger1.GetInstance().Error("Exception LoginController.DoLogin()", e.Message);
                return View("LoginError");
            }





        }
    }
}