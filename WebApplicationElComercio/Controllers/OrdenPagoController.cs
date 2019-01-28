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
    [Authorize(Roles = "Operador2,Administrador")]
    public class OrdenPagoController : Controller
    {
        private readonly IOrdenPagoBusiness _ordenPagoBusiness;
        private readonly ISucursalBusiness _sucursalBusiness;

        public OrdenPagoController(IOrdenPagoBusiness ordenPagoBusiness,
                                    ISucursalBusiness sucursalBusiness)
        {
            _ordenPagoBusiness = ordenPagoBusiness;
            _sucursalBusiness = sucursalBusiness;
        }


        // GET: OrdenPago
        public ActionResult Index()
        {
            var result = _ordenPagoBusiness.GetAll();
            var mappedresult = AutoMapper.Mapper.Map<List<OrdenPago>>(result);
            return View(mappedresult);
        }

        // GET: OrdenPago/Details/5
        public ActionResult Details(int id)
        {
            var result = _ordenPagoBusiness.GetById(id);
            var mappedresult = AutoMapper.Mapper.Map<OrdenPago>(result);
            return View(mappedresult);
        }

        // GET: OrdenPago/Create
        public ActionResult Create()
        {
            var listSucursales = AutoMapper.Mapper.Map<List<Sucursal>>(_sucursalBusiness.GetAll());
            ViewBag.ListSurcusales = listSucursales.Select(x => new SelectListItem() { Text = x.nombre, Value = x.idsucursal.ToString() }).ToList();
            return View();
        }

        // POST: OrdenPago/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdenPago collection)
        {
            try
            {
                var mappedresult = AutoMapper.Mapper.Map<Entities.OrdenPago>(collection);
                _ordenPagoBusiness.Insert(mappedresult);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Edit/5
        public ActionResult Edit(int id)
        {

            var listSucursales = AutoMapper.Mapper.Map<List<Sucursal>>(_sucursalBusiness.GetAll());
            ViewBag.ListSurcusales = listSucursales.Select(x => new SelectListItem() { Text = x.nombre, Value = x.idsucursal.ToString() }).ToList();
            var result = _ordenPagoBusiness.GetById(id);
            var mappedresult = AutoMapper.Mapper.Map<OrdenPago>(result);
            return View(mappedresult);
        }

        // POST: OrdenPago/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrdenPago collection)
        {
            try
            {
                var mappedresult = AutoMapper.Mapper.Map<Entities.OrdenPago>(collection);
                _ordenPagoBusiness.Update(id, mappedresult);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Delete/5
        public ActionResult Delete(int id)
        {
            var listSucursales = AutoMapper.Mapper.Map<List<Sucursal>>(_sucursalBusiness.GetAll());
            ViewBag.ListSurcusales = listSucursales.Select(x => new SelectListItem() { Text = x.nombre, Value = x.idsucursal.ToString() }).ToList();
            var result = _ordenPagoBusiness.GetById(id);
            var mappedresult = AutoMapper.Mapper.Map<OrdenPago>(result);
            return View(mappedresult);
        }

        // POST: OrdenPago/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _ordenPagoBusiness.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}