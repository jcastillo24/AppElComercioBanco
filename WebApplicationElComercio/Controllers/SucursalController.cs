using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationElComercio.Models;

namespace WebApplicationElComercio.Controllers
{
    [Authorize(Roles = "Operador1,Administrador")]
    public class SucursalController : Controller
    {

        private readonly ISucursalBusiness _sucursalBusiness;
        private readonly IBancoBusiness _bancoBusiness;


        public SucursalController(ISucursalBusiness sucursalBusiness,
                                  IBancoBusiness bancoBusiness)
        {
            _sucursalBusiness = sucursalBusiness;
            _bancoBusiness = bancoBusiness;
        }

        // GET: Sucursal
        public ActionResult Index()
        {
            var result = _sucursalBusiness.GetAll();
            var mappedresult = AutoMapper.Mapper.Map<List<Sucursal>>(result);
            return View(mappedresult);
        }

        // GET: Sucursal/Details/5
        public ActionResult Details(int id)
        {
            var result = _sucursalBusiness.GetById(id);
            var mappedresult = AutoMapper.Mapper.Map<Sucursal>(result);
            return View(mappedresult);
        }

        // GET: Sucursal/Create
        public ActionResult Create()
        {
            var list = AutoMapper.Mapper.Map<List<Banco>>(_bancoBusiness.GetAll());
            ViewBag.ListBancos = list.Select(x => new SelectListItem() { Text = x.nombre, Value = x.idbanco.ToString() }).ToList();
            return View();
        }

        // POST: Sucursal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sucursal collection)
        {
            try
            {
                var mappedresult = AutoMapper.Mapper.Map<Entities.Sucursal>(collection);
                _sucursalBusiness.Insert(mappedresult);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Edit/5
        public ActionResult Edit(int id)
        {
            var list = AutoMapper.Mapper.Map<List<Banco>>(_bancoBusiness.GetAll());
            ViewBag.ListBancos = list.Select(x => new SelectListItem() { Text = x.nombre, Value = x.idbanco.ToString() }).ToList();
            var result = _sucursalBusiness.GetById(id);
            var mappedresult = AutoMapper.Mapper.Map<Sucursal>(result);
            return View(mappedresult);
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sucursal collection)
        {
            try
            {
                var mappedresult = AutoMapper.Mapper.Map<Entities.Sucursal>(collection);
                _sucursalBusiness.Update(id, mappedresult);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Delete/5
        public ActionResult Delete(int id)
        {
            var list = AutoMapper.Mapper.Map<List<Banco>>(_bancoBusiness.GetAll());
            ViewBag.ListBancos = list.Select(x => new SelectListItem() { Text = x.nombre, Value = x.idbanco.ToString() }).ToList();
            var result = _sucursalBusiness.GetById(id);
            var mappedresult = AutoMapper.Mapper.Map<Sucursal>(result);
            return View(mappedresult);
        }

        // POST: Sucursal/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Sucursal collection)
        {
            try
            {
                _sucursalBusiness.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}