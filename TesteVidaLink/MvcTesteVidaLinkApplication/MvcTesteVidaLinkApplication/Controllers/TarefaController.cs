using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTesteVidaLinkApplication.Models;

namespace MvcTesteVidaLinkApplication.Controllers
{
    public class TarefaController : Controller
    {
        private TesteVidaLinkEntities db = new TesteVidaLinkEntities();

        //
        // GET: /Tarefa/
        
        public ActionResult Index()
        {           
            return View(db.Tarefa.ToList());            
        }
        [HttpPost]
        public ActionResult Index(string Localizar)
        {
            if (!String.IsNullOrEmpty(Localizar))
            {
                return View(db.Tarefa.Where(x => x.nm_Titulo.Contains(Localizar)).ToList());
            }
            else
            {
                return View(db.Tarefa.ToList());
            }
        }
        

        //
        // GET: /Tarefa/Details/5

        public ActionResult Details(int id = 0)
        {
            Tarefa tarefa = db.Tarefa.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        //
        // GET: /Tarefa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tarefa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Tarefa.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarefa);
        }

        //
        // GET: /Tarefa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tarefa tarefa = db.Tarefa.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        //
        // POST: /Tarefa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        //
        // GET: /Tarefa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tarefa tarefa = db.Tarefa.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        //
        // POST: /Tarefa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefa tarefa = db.Tarefa.Find(id);
            db.Tarefa.Remove(tarefa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}