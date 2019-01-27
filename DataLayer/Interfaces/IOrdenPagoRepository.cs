using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IOrdenPagoRepository
    {
        IEnumerable<OrdenPago> GetAll();
        OrdenPago GetById(int id);
        void Insert(OrdenPago value);
        void Update(int id, OrdenPago value);
        void Delete(int id);
        IEnumerable<OrdenPago> GetAllBySucursalAndMoney(int idSucursal, string moneda);
    }
}
