using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebMVC.Models;
using ProjetoWebMVC.Services;

namespace ProjetoWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Seller seller) 
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
            //redireciona a requisicao para o Index
        }
    }
}
