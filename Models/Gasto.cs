using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        [ForeignKey("categoriaGasto")]
        public int Tipo { get; set; }
        public CategoriaGasto categoriaGasto { get; set; }
    }
}
