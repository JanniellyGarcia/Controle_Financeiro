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
    public class CategoriaGanhoController : Controller
    {
        public IActionResult Index()
        {
            BDContext bd = new BDContext();
            var categoriaganho = bd.CategoriaGanho.ToList();

            return View(categoriaganho);
        }


        public ActionResult Create()
        {
            FillCategory(0);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaGanho obj)
        {
            BDContext bd = new BDContext();
            if (ModelState.IsValid)
            {
                bd.CategoriaGanho.Add(obj);
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
            var cateoriaganho = db.CategoriaGanho.Find(id);

            return View(cateoriaganho);
        }


        public ActionResult Edit(int id)
        {
            BDContext db = new BDContext();
            var categoriaganho = db.CategoriaGanho.Find(id);

            return View(categoriaganho);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaGanho obj)
        {
            BDContext db = new BDContext();
            if (ModelState.IsValid)
            {

                using (var dbContext = new BDContext())
                {
                    CategoriaGanho categoriaganho = db.CategoriaGanho.First(g => g.Id == obj.Id);
                    categoriaganho.Name = obj.Name;
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
        public ActionResult Delete(CategoriaGanho obj)
        {
            BDContext db = new BDContext();
            if (ModelState.IsValid)
            {
                CategoriaGanho categoriaganho = db.CategoriaGanho.Find(obj.Id);
                db.CategoriaGanho.Remove(categoriaganho);
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

            ViewBag.CategoryId = new SelectList(db.CategoriaGanho.ToList(), "Id", "Name", id);

        }
    }
}
