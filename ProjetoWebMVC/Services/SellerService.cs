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
    }
}
