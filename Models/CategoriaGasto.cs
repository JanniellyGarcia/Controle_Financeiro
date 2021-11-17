using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Financeiro.Models
{
    public class CategoriaGasto
    {
        public int Id { get; set; }
        [DisplayName("Categoria")]
        public string Name { get; set; }
    }
}
