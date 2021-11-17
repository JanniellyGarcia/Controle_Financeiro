using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    public class Ganho
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        [ForeignKey("categoriaGanho")]
        public int Tipo { get; set; }
        public CategoriaGanho categoriaGanho { get; set; }
    }
}
