using Microsoft.EntityFrameworkCore;
using ProjetoWebMVC.Data;
using ProjetoWebMVC.Models;
using ProjetoWebMVC.Services.Exceptions;
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
        {//cria uma lista de vendedores
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj) 
        {//inserir vendedor
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id) 
        {//faz a busca pelo ID
            return _context.Seller.Include(obj => obj.Departament)
                .FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {//deletar vendedor
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {/*verificando se existe algum id no banco 
         semelhante ao que voce esta procurando
            se nao existir, a excecao eh lançada*/

            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            /*usando o try/catch pois pode haver uma excecao do banco
            sobre ao usar o "update", sobre conflito de concorrência
            */
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
