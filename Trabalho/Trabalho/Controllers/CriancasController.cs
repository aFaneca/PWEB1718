using Microsoft.AspNet.Identity;
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
    public class CriancasController : Controller
    {
        private TPContext db = new TPContext();

        // GET: Criancas
        public ActionResult Index()
        {
            var criancas = db.Criancas.Include(c => c.Candidatura);
            return View(criancas.ToList());
        }

        // GET: Criancas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crianca crianca = db.Criancas.Find(id);
            if (crianca == null)
            {
                return HttpNotFound();
            }
            return View(crianca);
        }

        // GET: Criancas/Create
        public ActionResult Create()
        {
            ViewBag.CandidaturaId = new SelectList(db.Candidaturas, "CandidaturaId", "Estado");
            return View();
        }

        // POST: Criancas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CriancaId,Idade,Nome,UserId,CandidaturaId")] Crianca crianca)
        {
            if (ModelState.IsValid)
            {
                crianca.UserId = User.Identity.GetUserId();
                db.Criancas.Add(crianca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandidaturaId = new SelectList(db.Candidaturas, "CandidaturaId", "Estado", crianca.CandidaturaId);
            return View(crianca);
        }

        // GET: Criancas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crianca crianca = db.Criancas.Find(id);
            if (crianca == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidaturaId = new SelectList(db.Candidaturas, "CandidaturaId", "Estado", crianca.CandidaturaId);
            return View(crianca);
        }

        // POST: Criancas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CriancaId,Idade,Nome,UserId,CandidaturaId")] Crianca crianca)
        {
            if (ModelState.IsValid)
            {
                crianca.UserId = User.Identity.GetUserId();
                db.Entry(crianca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidaturaId = new SelectList(db.Candidaturas, "CandidaturaId", "Estado", crianca.CandidaturaId);
            return View(crianca);
        }

        // GET: Criancas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crianca crianca = db.Criancas.Find(id);
            if (crianca == null)
            {
                return HttpNotFound();
            }
            return View(crianca);
        }

        // POST: Criancas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crianca crianca = db.Criancas.Find(id);
            db.Criancas.Remove(crianca);
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
