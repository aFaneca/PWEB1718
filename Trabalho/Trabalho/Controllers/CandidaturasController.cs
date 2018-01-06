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
    
    public class CandidaturasController : Controller
    {
        private TPContext db = new TPContext();


        [Authorize(Roles = "Instituição")]
        public ActionResult Lista()
        {
            var UId = User.Identity.GetUserId();
            List<Instituicao> insts = db.Instituicaos.Where(x => x.UserId == UId).ToList();
            //ViewBag.NomesInstituicoes = new SelectList(db.Instituicaos.Where(x => x.UserId == User.Identity.GetUserId()), "ID", "Nome");
            ViewBag.NomesInstituicoes = insts;
            foreach(var x in db.Candidaturas.ToList())
            {
                x.NomeInstituicao = db.Instituicaos.Find(x.InstituicaoId).Nome;
            }
            foreach (var x in db.Candidaturas.ToList())
            {
                x.NomeCrianca = db.Criancas.Find(x.CriancaId).Nome;
            }
            return View(db.Candidaturas.ToList());
        }

        [Authorize(Roles = "Instituição")]
        public ActionResult Aprovar(int id)
        {
            
                foreach (var x in db.Candidaturas.ToList())
                {
                    if (id == x.CandidaturaId)
                    {
                        x.Estado = "Aprovado";
                        db.Entry(x).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            
            
            return RedirectToAction("Lista");
        }

        [Authorize(Roles = "Instituição")]
        public ActionResult Rejeitar(int id)
        {
            foreach (var x in db.Candidaturas.ToList())
            {
                if (id == x.CandidaturaId)
                {
                    x.Estado = "Rejeitado";
                    db.Entry(x).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Lista");
        }

        [Authorize(Roles = "Pais")]
        public JavaScriptResult ErroAvaliar()
        {
            string a = "alert('Precisa de ter uma candidatura aceite na Instituição para a poder avaliar!')";
            return JavaScript(a);
        }



        // GET: Candidaturas/Avaliar/5
        [Authorize(Roles = "Pais")]
        public ActionResult Avaliar(int id)
        {

            Candidatura candidatura = db.Candidaturas.Find(id);
            if(candidatura.Estado != "Aprovado")
                return RedirectToAction("ErroAvaliar");
            var a = candidatura.InstituicaoId;
            if (candidatura == null)
            {
                return HttpNotFound();
            }
            return View(candidatura);
        }


        // POST: Candidaturas/Avaliar
        [Authorize(Roles = "Pais")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Avaliar([Bind(Include = "Avaliacao, InstituicaoId")] Candidatura candidatura, int id)
        {
            if (ModelState.IsValid)
            {

                //candidatura.Estado = "Em Análise";
                //candidatura.UserId = User.Identity.GetUserId();
                //var instituicao = db.Instituicaos.Find(candidatura);
                //candidatura = db.Candidaturas.Find(id);
                var instituicao = db.Instituicaos.Find(db.Candidaturas.Find(id).InstituicaoId);
                instituicao.PontuacaoTotal += candidatura.Avaliacao.Value;
                instituicao.Avaliacoes++;
                instituicao.RatingMedio = instituicao.PontuacaoTotal / instituicao.Avaliacoes;
                //db.Entry(candidatura).State = EntityState.Modified;
                db.Entry(instituicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidatura);
        }

        // GET: Candidaturas
        [Authorize(Roles = "Pais, Administrador")]
        public ActionResult Index()
        {
            return View(db.Candidaturas.ToList());
        }

        


        // GET: Candidaturas/Details/5
        [Authorize(Roles = "Pais, Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatura candidatura = db.Candidaturas.Find(id);
            if (candidatura == null)
            {
                return HttpNotFound();
            }
            return View(candidatura);
        }

        // GET: Candidaturas/Create
        [Authorize(Roles = "Pais, Administrador")]
        public ActionResult Create()
        {
            
            var uId = User.Identity.GetUserId();
            ViewBag.NomesCriancas = new SelectList(db.Criancas.Where(x => x.UserId == uId), "CriancaId", "Nome");
            ViewBag.NomesInstituicoes = new SelectList(db.Instituicaos, "ID", "Nome");
            return View();
        }

        // POST: Candidaturas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pais, Administrador")]
        public ActionResult Create([Bind(Include = "CandidaturaId,Estado,CriancaId,InstituicaoId")] Candidatura candidatura)
        {
            if (ModelState.IsValid)
            {
                candidatura.Estado = "Em Análise";
                candidatura.UserId = User.Identity.GetUserId();
                //candidatura.Avaliacao = 0;
                db.Candidaturas.Add(candidatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidatura);
        }

        // GET: Candidaturas/Edit/5
        [Authorize(Roles = "Pais, Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatura candidatura = db.Candidaturas.Find(id);
            var uId = User.Identity.GetUserId();
            ViewBag.CriancaId = new SelectList(db.Criancas.Where(x => x.UserId == uId), "CriancaId", "Nome", candidatura.CriancaId);
            ViewBag.InstituicaoId = new SelectList(db.Instituicaos, "ID", "Nome", candidatura.InstituicaoId);

            if (candidatura == null)
            {
                return HttpNotFound();
            }
            return View(candidatura);
        }

        // POST: Candidaturas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pais, Administrador")]
        public ActionResult Edit([Bind(Include = "CandidaturaId,Estado,CriancaId,InstituicaoId")] Candidatura candidatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidatura);
        }

        // GET: Candidaturas/Delete/5
        [Authorize(Roles = "Pais, Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatura candidatura = db.Candidaturas.Find(id);
            if (candidatura == null)
            {
                return HttpNotFound();
            }
            return View(candidatura);
        }

        // POST: Candidaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pais, Administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidatura candidatura = db.Candidaturas.Find(id);
            db.Candidaturas.Remove(candidatura);
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
