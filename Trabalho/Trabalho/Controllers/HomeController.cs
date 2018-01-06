using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trabalho.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A solução perfeita para os seus filhos!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Estamos à espera do seu feedback.";

            return View();
        }
    }
}