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
    [Authorize(Roles = "Instituição, Administrador")]
    public class InstituicoesController : Controller
    {
        private TPContext db = new TPContext();

        [Authorize(Roles = "Administrador")]
        public ActionResult Todas()
        {
            return View("Todas/Index", db.Instituicaos.ToList());
        }

        //[AllowAnonymous]
        //public ActionResult Index()
        //{
        //    if (!User.IsInRole("Administrador") && !User.IsInRole("Instituição"))
        //        return RedirectToAction("Lista");
        //    return View(db.Instituicaos.ToList());
        //}


            // GET: Instituicoes
            public ActionResult Index()
        {
            
            return View(db.Instituicaos.ToList());
        }

        [AllowAnonymous]
        public ActionResult Lista()
        {

            return View(db.Instituicaos.ToList());
        }

        [AllowAnonymous]
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicaos.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }


        // GET: Instituicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicaos.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // GET: Instituicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instituicoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Tipo,Creche,PreEscolar,TransporteCriancas,AulasNatacao,AulasMusica,Valor,UserId")] Instituicao instituicao)
        {
           
                

                if (ModelState.IsValid)
                {

                    instituicao.UserId = User.Identity.GetUserId();
                    instituicao.Rating = instituicao.Avaliacoes = instituicao.PontuacaoTotal = 0;
                    instituicao.RatingMedio = 0.0;
                    db.Instituicaos.Add(instituicao);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            

            return View(instituicao);
        }

        // GET: Instituicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicaos.Find(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Tipo,Creche,PreEscolar,TransporteCriancas,AulasNatacao,AulasMusica,Valor,UserId,PontuacaoTotal,Rating,Avaliacoes,RatingMedio")] Instituicao instituicao)
        {
            // return Content(ModelState.Keys.FirstOrDefault());
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                instituicao.UserId = User.Identity.GetUserId();
                db.Entry(instituicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instituicao);
        }

        // GET: Instituicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = db.Instituicaos.Find(id);
            //instituicao.RatingMedio = instituicao.MediaAvaliacoes(instituicao.PontuacaoTotal.Value, instituicao.Avaliacoes.Value);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instituicao instituicao = db.Instituicaos.Find(id);
            db.Instituicaos.Remove(instituicao);
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



