using Controle_Financeiro.Context;
using Controle_Financeiro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Financeiro.Controllers
{
    public class GanhoController : Controller
    {
        public IActionResult Index()
        {
            BDContext bd = new BDContext();
            var categoriaganho = bd.Ganho
                            .Include("CategoriaGanho")
                            .ToList();

            return View(categoriaganho);
        }
        public ActionResult Create()
        {
            FillCategory(0);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ganho obj)
        {
            BDContext db = new BDContext();
            if (ModelState.IsValid)
            {
                db.Ganho.Add(obj);
                db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        public ActionResult Details(int id)
        {
            BDContext db = new BDContext();
            var ganho = db.Ganho.Find(id);

            return View(ganho);
        }

        public ActionResult Edit(int id)
        {
            BDContext db = new BDContext();
            var ganho = db.Ganho.Find(id);

            return View(ganho);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ganho obj)
        {
            BDContext db = new BDContext();
            if (ModelState.IsValid)
            {

                using (var dbContext = new BDContext())
                {
                    Ganho ganho = db.Ganho.First(g => g.Id == obj.Id);
                    ganho.Nome = obj.Nome;
                    dbContext.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }

        public ActionResult Delete(int id)
        {
            BDContext db = new BDContext();
            var ganho = db.Ganho.Find(id);

            return View(ganho);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Ganho obj)
        {
            BDContext db = new BDContext();
            if (ModelState.IsValid)
            {
                Ganho ganho = db.Ganho.Find(obj.Id);
                db.Ganho.Remove(ganho);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }

        }

        public void FillCategory(int id)
        {
            BDContext db = new BDContext();

            ViewBag.CategoriaGanho = new SelectList(db.CategoriaGanho.ToList(), "Id", "Name", id);

        }
    }
}
