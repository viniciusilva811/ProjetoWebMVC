using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWebMVC.Models.ViewModels
{
    public class SellerFormViewModel
    {//tem os dados do formulario de cadastro de vendendor
        public Seller Seller { get; set; }
        public ICollection<Departament> Departaments { get; set; }
    }
}
