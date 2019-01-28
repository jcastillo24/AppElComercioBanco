using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationElComercio.Models;

namespace WebApplicationElComercio.Controllers
{
    //[Authorize(Roles = "Operador1,Administrador")]
    public class BancoController : Controller
    {
        private readonly IBancoBusiness _bancoBusiness;

        public BancoController(IBancoBusiness bancoBusiness)
        {
            _bancoBusiness = bancoBusiness;
        }


        // GET: Banco
        public ActionResult Index()
        {
            var result = _bancoBusiness.GetAll();
            var mappedresult = AutoMapper.Mapper.Map<List<Banco>>(result);
            return View(mappedresult);
        }

        // GET: Banco/Details/5
        public ActionResult Details(int id)
        {
            var result = _bancoBusiness.GetById(id);
            var mappedresult = AutoMapper.Mapper.Map<Banco>(result);
            return View(mappedresult);
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Banco collection)
        {
            try
            {
                var mappedresult = AutoMapper.Mapper.Map<Entities.Banco>(collection);
                _bancoBusiness.Insert(mappedresult);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _bancoBusiness.GetById(id);
            var mappedresult = AutoMapper.Mapper.Map<Banco>(result);
            return View(mappedresult);
        }

        // POST: Banco/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Banco collection)
        {
            try
            {
                var mappedresult = AutoMapper.Mapper.Map<Entities.Banco>(collection);
                _bancoBusiness.Update(id,mappedresult);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _bancoBusiness.GetById(id);
            var mappedresult = AutoMapper.Mapper.Map<Banco>(result);
            return View(mappedresult);
        }

        // POST: Banco/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Banco collection)
        {
            try
            {
                _bancoBusiness.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}