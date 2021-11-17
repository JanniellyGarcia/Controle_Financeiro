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
    public class GastoController : Controller
    {
        public IActionResult Index()
        {
            BDContext bd = new BDContext();
            var categoriagasto = bd.Gasto
                            .Include("CategoriaGasto")
                            .ToList();

            return View(categoriagasto);
        }
        public ActionResult Create()
        {
            FillCategory(0);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gasto obj)
        {
            BDContext db = new BDContext();
            if (ModelState.IsValid)
            {
                db.Gasto.Add(obj);
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
            var gasto = db.Gasto.Find(id);

            return View(gasto);
        }


        public ActionResult Edit(int id)
        {
            BDContext db = new BDContext();
            var gasto = db.Gasto.Find(id);

            return View(gasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gasto obj)
        {
            BDContext db = new BDContext();
            if (ModelState.IsValid)
            {

                using (var dbContext = new BDContext())
                {
                    Gasto gasto = db.Gasto.First(g => g.Id == obj.Id);
                    gasto.Nome = obj.Nome;
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
            var gasto = db.Gasto.Find(id);

            return View(gasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Gasto obj)
        {
            BDContext db = new BDContext();
            if (ModelState.IsValid)
            {
                Gasto gasto = db.Gasto.Find(obj.Id);
                db.Gasto.Remove(gasto);
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

            ViewBag.CategoriaGasto = new SelectList(db.CategoriaGasto.ToList(), "Id", "Name", id);

        }




    }
}
