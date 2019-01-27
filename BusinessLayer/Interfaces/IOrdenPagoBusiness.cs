using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IOrdenPagoBusiness
    {
        IEnumerable<OrdenPago> GetAll();
        IEnumerable<OrdenPago> GetAllBySucursalAndMoney(int idSucursal, string moneda);
        OrdenPago GetById(int id);
        void Insert(OrdenPago value);
        void Update(int id, OrdenPago value);
        void Delete(int id);
    }
}
