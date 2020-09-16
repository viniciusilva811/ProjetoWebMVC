using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoWebMVC.Models;

namespace ProjetoWebMVC.Data
{
    public class ProjetoWebMVCContext : DbContext
    {
        public ProjetoWebMVCContext (DbContextOptions<ProjetoWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Departament> Departament { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }

    }
}
