using Microsoft.EntityFrameworkCore;
using ProjetoWebMVC.Data;
using ProjetoWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWebMVC.Services
{
    public class SellerService
    {
        private readonly ProjetoWebMVCContext _context;

        public SellerService(ProjetoWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj) 
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id) 
        {//puxa o ID do departamento dentro da pagina
            return _context.Seller.Include(obj => obj.Departament)
                .FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
