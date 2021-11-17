using Controle_Financeiro.Context;
using Controle_Financeiro.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Financeiro.Controllers
{
    public class ExtratoController : Controller
    {
        public IActionResult Index()
        {
            BDContext bd = new BDContext();
            var extratoGasto = bd.Gasto.Sum(y => y.Valor);
            var extratoGanho = bd.Ganho.Sum(y => y.Valor);
            
            var Saldo = extratoGanho - extratoGasto;

            Extrato.extratoganho = extratoGanho;
            Extrato.extratogasto= extratoGasto;
            Extrato.saldo = Saldo;



            return View();
        }
    }
}
