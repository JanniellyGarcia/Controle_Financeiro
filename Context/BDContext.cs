using Controle_Financeiro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Financeiro.Context
{
    public class BDContext : DbContext
    {
        public BDContext() : base("ControleFinanceiro")
        {

        }
        public DbSet<Ganho> Ganho { get; set; }
        public DbSet<CategoriaGanho> CategoriaGanho { get; set; }
        public DbSet<Gasto> Gasto { get; set; }
        public DbSet<CategoriaGasto> CategoriaGasto { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
