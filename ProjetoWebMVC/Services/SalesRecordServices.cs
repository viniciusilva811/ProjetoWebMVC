using Microsoft.EntityFrameworkCore;
using ProjetoWebMVC.Data;
using ProjetoWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly ProjetoWebMVCContext _context;

        public SalesRecordService(ProjetoWebMVCContext context)
        {
            _context = context;
        }

        public List<SalesRecord> FindByDate(DateTime? minDate, DateTime? maxDate) 
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {//data minima
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {//data maxima
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return result//faz o join com as tabelas
                .Include(x => x.Seller)
                .Include(x => x.Seller.Departament)
                .OrderByDescending(x => x.Date)
                .ToList();
        }
    }
}