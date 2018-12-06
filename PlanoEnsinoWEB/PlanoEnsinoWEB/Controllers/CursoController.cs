using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlanoEnsinoWEB.Models;
using PagedList;

namespace PlanoEnsinoWEB.Controllers
{
    public class CursoController : Controller
    {
        private PlanoEnsinoContext db = new PlanoEnsinoContext();

        // GET: Curso
        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Data" ? "date_desc" : "Data";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var cursos = from s in db.Cursoes
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                cursos = cursos.Where(s => s.nome.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nome_desc":
                    cursos = cursos.OrderByDescending(s => s.nome);
                    break;
                case "Data":
                    cursos = cursos.OrderBy(s => s.objetivo);
                    break;
                case "data_desc":
                    cursos = cursos.OrderByDescending(s => s.objetivo);
                    break;
                default:
                    cursos = cursos.OrderBy(s => s.nome);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(cursos.ToPagedList(pageNumber, pageSize));
            //return View(db.Cursoes.ToList());
        }

        // GET: Curso/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

       /* public ActionResult Pesquisa()
        {
            using (var db = new PlanoEnsinoContext())
            {
                var _curso = db.Cursoes.ToList();
                var data = new Curso()
                {
                    Cursos = _curso
                };
                return View(data);
            }
        }*/

        /*[HttpPost]
        public ActionResult Pesquisa(Curso _curso)
        {
            using (var db = new PlanoEnsinoContext())
            {
                var cursoPesquisa = from cursorec in db.Cursoes
                                      where ((_curso.nome == null) || (cursorec.nome == _curso.nome.Trim()))
                             
                                      select new
                                      {
                                          IdCurso = cursorec.IdCurso,
                                          nome = cursorec.nome,
                                          objetivo = cursorec.objetivo,
                                       
                                      };
                List<Curso> ListaCursos = new List<Curso>();

                foreach (var reg in cursoPesquisa)
                {
                    Curso cursoValor = new Curso();
                    cursoValor.IdCurso = reg.IdCurso;
                    cursoValor.nome = reg.nome;
                    cursoValor.objetivo = reg.objetivo;
                    
                    ListaCursos.Add(cursoValor);
                }

                _curso. = ListaCursos;

                return View(_curso);
            }
        }*/
    



// GET: Curso/Create
[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "IdCurso,nome,objetivo")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursoes.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curso);
        }

        // GET: Curso/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "IdCurso,nome,objetivo")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        // GET: Curso/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursoes.Find(id);
            db.Cursoes.Remove(curso);
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
