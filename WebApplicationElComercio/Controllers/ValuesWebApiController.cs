using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationElComercio.Controllers
{
    [Route("api/[controller]")]
    public class ValuesWebApiController : Controller
    {

        private readonly IOrdenPagoBusiness _ordenPagoBusiness;
        private readonly ISucursalBusiness _sucursalBusiness;

        public ValuesWebApiController(IOrdenPagoBusiness ordenPagoBusiness,
                                    ISucursalBusiness sucursalBusiness)
        {
            _ordenPagoBusiness = ordenPagoBusiness;
            _sucursalBusiness = sucursalBusiness;
        }


        [HttpGet]
        [Route("ListOrdenPagoBySucursal/{sucursalId}/{moneda?}")]
        public IEnumerable<OrdenPago> ListOrdenPagoBySucursal(int sucursalId, string moneda = null)
        {
            return _ordenPagoBusiness.GetAllBySucursalAndMoney(sucursalId, moneda);
        }

        [HttpGet]
        [Route("ListSucursalByBanco/{bancoId}")]
        // GET: api/Sucursal
        public IEnumerable<Sucursal> ListSucursalByBanco(int bancoId)
        {
            return _sucursalBusiness.GetAllByIdBanco(bancoId);
        }

    }
}
