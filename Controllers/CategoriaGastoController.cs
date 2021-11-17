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
    public class CategoriaGastoController : Controller
    {
        public IActionResult Index()
        {
            BDContext bd = new BDContext();
            var categoriagasto = bd.CategoriaGasto.ToList();

            return View(categoriagasto);
        }
        public ActionResult Create()
        {
            FillCategory(0);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaGasto obj)
        {
            BDContext bd = new BDContext();
            if (ModelState.IsValid)
            {
               bd.CategoriaGasto.Add(obj);
               bd.SaveChangesAsync();

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
            var cateoriagasto = db.CategoriaGasto.Find(id);

            return View(cateoriagasto);
        }


        public ActionResult Edit(int id)
        {
            BDContext db = new BDContext();
            var categoriagasto = db.CategoriaGasto.Find(id);

            return View(categoriagasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaGasto obj)
        {
            BDContext db = new BDContext();
            if (ModelState.IsValid)
            {

                using (var dbContext = new BDContext())
                {
                    CategoriaGasto categoriagasto = db.CategoriaGasto.First(g => g.Id == obj.Id);
                    categoriagasto.Name = obj.Name;
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
            var categoriagasto = db.CategoriaGasto.Find(id);

            return View(categoriagasto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoriaGasto obj)
        {
            BDContext db = new BDContext();
            if (ModelState.IsValid)
            {
                CategoriaGasto categoriagasto = db.CategoriaGasto.Find(obj.Id);
                db.CategoriaGasto.Remove(categoriagasto);
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
