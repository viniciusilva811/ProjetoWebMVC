﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebMVC.Models;
using ProjetoWebMVC.Models.ViewModels;
using ProjetoWebMVC.Services;
using ProjetoWebMVC.Services.Exceptions;

namespace ProjetoWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        private readonly DepartamentService _departamentService;

        public SellersController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerService = sellerService;
            _departamentService = departamentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departaments = _departamentService.FindAll();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel); //pegar os departamentos na hora da criaçao
        }
        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
            //redireciona a requisicao para o Index
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
                _sellerService.Remove(id);
                return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se o id nao for nulo, a tela de edit pode abrir
            var obj =  _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            //puxa os departamentos e popula a caixa de selecao
            List<Departament> departments = _departamentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { 
                Seller = obj, 
                Departaments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departamentService.FindAll();
                var viewModel = new SellerFormViewModel { 
                    Seller = seller, 
                    Departaments = departments };
                return View(viewModel);
            }
            if (id != seller.Id)
            {
                return BadRequest();
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
