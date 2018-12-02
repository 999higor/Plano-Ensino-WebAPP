using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlanoEnsinoWEB.Models;

namespace PlanoEnsinoWEB.Controllers
{
    public class PlanoEnsinoController : Controller
    {
        private PlanoEnsinoContext db = new PlanoEnsinoContext();

        // GET: PlanoEnsino
        [Authorize]
        public ActionResult Index()
        {
            var planoEnsinoes = db.PlanoEnsinoes.Include(p => p.ComponenteCurricular);
            return View(planoEnsinoes.ToList());
        }

        // GET: PlanoEnsino/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoEnsino planoEnsino = db.PlanoEnsinoes.Find(id);
            if (planoEnsino == null)
            {
                return HttpNotFound();
            }
            return View(planoEnsino);
        }

        // GET: PlanoEnsino/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.codigo_componente_curricular = new SelectList(db.ComponenteCurriculars, "IdComponenteCurricular", "nome");
            return View();
        }

        // POST: PlanoEnsino/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "IdPlanoEnsino,ano,semestre_letivo,colegiado,possibilidade_integracao,avaliacao_curricular,referencias_aprofundamento,conteudo_programado,cronograma,estrategia_recuperacao,metodologia,codigo_componente_curricular,professores,nome")] PlanoEnsino planoEnsino)
        {
            if (ModelState.IsValid)
            {
                db.PlanoEnsinoes.Add(planoEnsino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_componente_curricular = new SelectList(db.ComponenteCurriculars, "IdComponenteCurricular", "nome", planoEnsino.codigo_componente_curricular);
            return View(planoEnsino);
        }

        // GET: PlanoEnsino/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoEnsino planoEnsino = db.PlanoEnsinoes.Find(id);
            if (planoEnsino == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_componente_curricular = new SelectList(db.ComponenteCurriculars, "IdComponenteCurricular", "nome", planoEnsino.codigo_componente_curricular);
            return View(planoEnsino);
        }

        // POST: PlanoEnsino/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "IdPlanoEnsino,ano,semestre_letivo,colegiado,possibilidade_integracao,avaliacao_curricular,referencias_aprofundamento,conteudo_programado,cronograma,estrategia_recuperacao,metodologia,codigo_componente_curricular,professores,nome")] PlanoEnsino planoEnsino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planoEnsino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_componente_curricular = new SelectList(db.ComponenteCurriculars, "IdComponenteCurricular", "nome", planoEnsino.codigo_componente_curricular);
            return View(planoEnsino);
        }

        // GET: PlanoEnsino/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanoEnsino planoEnsino = db.PlanoEnsinoes.Find(id);
            if (planoEnsino == null)
            {
                return HttpNotFound();
            }
            return View(planoEnsino);
        }

        // POST: PlanoEnsino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanoEnsino planoEnsino = db.PlanoEnsinoes.Find(id);
            db.PlanoEnsinoes.Remove(planoEnsino);
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
