using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trabalho.Models;

namespace Trabalho.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PescadoresController : Controller
    {
        private TPContext db = new TPContext();

        // GET: Pescadores
        public ActionResult Index()
        {
            return View(db.Pescadors.ToList());
        }

        // GET: Pescadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pescador pescador = db.Pescadors.Find(id);
            if (pescador == null)
            {
                return HttpNotFound();
            }
            return View(pescador);
        }

        // GET: Pescadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pescadores/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MyProperty")] Pescador pescador)
        {
            if (ModelState.IsValid)
            {
                db.Pescadors.Add(pescador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pescador);
        }

        // GET: Pescadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pescador pescador = db.Pescadors.Find(id);
            if (pescador == null)
            {
                return HttpNotFound();
            }
            return View(pescador);
        }

        // POST: Pescadores/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MyProperty")] Pescador pescador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pescador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pescador);
        }

        // GET: Pescadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pescador pescador = db.Pescadors.Find(id);
            if (pescador == null)
            {
                return HttpNotFound();
            }
            return View(pescador);
        }

        // POST: Pescadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pescador pescador = db.Pescadors.Find(id);
            db.Pescadors.Remove(pescador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
