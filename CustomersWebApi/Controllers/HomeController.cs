using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomersWebApi.Controllers
{
    public class HomeController : Controller
    {
        //log4net
        private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      
        public ActionResult Index()
        {
            log.Error("-------Error message-------------");
            log.Fatal("-------Fatal message-------------");

            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
