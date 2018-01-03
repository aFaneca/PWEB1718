using System.Linq;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.EntityFramework;
using Trabalho.Models;

namespace Trabalho.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PerfilController : Controller
    {
        ApplicationDbContext context;

        public PerfilController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}