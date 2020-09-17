using ProjetoWebMVC.Data;
using ProjetoWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWebMVC.Services
{
    public class DepartamentService
    {
        private readonly ProjetoWebMVCContext _context;

        public DepartamentService(ProjetoWebMVCContext context)
        {
            _context = context;
        }

        public List<Departament> FindAll()
        {
            return _context.Departament.OrderBy(x => x.Name).ToList();
        }
    }
}
