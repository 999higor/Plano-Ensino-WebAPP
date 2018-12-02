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
    public class ComponenteCurricularController : Controller
    {
        private PlanoEnsinoContext db = new PlanoEnsinoContext();

        // GET: ComponenteCurricular
        [Authorize]
        public ActionResult Index()
        {
            var componenteCurriculars = db.ComponenteCurriculars.Include(c => c.Curso);
            return View(componenteCurriculars.ToList());
        }

        // GET: ComponenteCurricular/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComponenteCurricular componenteCurricular = db.ComponenteCurriculars.Find(id);
            if (componenteCurricular == null)
            {
                return HttpNotFound();
            }
            return View(componenteCurricular);
        }

        // GET: ComponenteCurricular/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.codigo_curso = new SelectList(db.Cursoes, "IdCurso", "nome");
            return View();
        }

        // POST: ComponenteCurricular/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComponenteCurricular,nome,semestre,objetivo,modalidade_oferta,ementa,referencias_basicas,referencias_complementares,hora_aula_distancia,hora_aula_presencial,hora_relogio_distancia,hora_relogio_presencial,codigo_curso")] ComponenteCurricular componenteCurricular)
        {
            if (ModelState.IsValid)
            {
                db.ComponenteCurriculars.Add(componenteCurricular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_curso = new SelectList(db.Cursoes, "IdCurso", "nome", componenteCurricular.codigo_curso);
            return View(componenteCurricular);
        }

        // GET: ComponenteCurricular/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComponenteCurricular componenteCurricular = db.ComponenteCurriculars.Find(id);
            if (componenteCurricular == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_curso = new SelectList(db.Cursoes, "IdCurso", "nome", componenteCurricular.codigo_curso);
            return View(componenteCurricular);
        }

        // POST: ComponenteCurricular/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "IdComponenteCurricular,nome,semestre,objetivo,modalidade_oferta,ementa,referencias_basicas,referencias_complementares,hora_aula_distancia,hora_aula_presencial,hora_relogio_distancia,hora_relogio_presencial,codigo_curso")] ComponenteCurricular componenteCurricular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(componenteCurricular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_curso = new SelectList(db.Cursoes, "IdCurso", "nome", componenteCurricular.codigo_curso);
            return View(componenteCurricular);
        }

        // GET: ComponenteCurricular/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComponenteCurricular componenteCurricular = db.ComponenteCurriculars.Find(id);
            if (componenteCurricular == null)
            {
                return HttpNotFound();
            }
            return View(componenteCurricular);
        }

        // POST: ComponenteCurricular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ComponenteCurricular componenteCurricular = db.ComponenteCurriculars.Find(id);
            db.ComponenteCurriculars.Remove(componenteCurricular);
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
