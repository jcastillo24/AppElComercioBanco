using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class OrdenPagoBusiness : IOrdenPagoBusiness
    {

        private readonly IOrdenPagoRepository _repository;
        public OrdenPagoBusiness(IOrdenPagoRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<OrdenPago> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<OrdenPago> GetAllBySucursalAndMoney(int idSucursal, string moneda)
        {
            return _repository.GetAllBySucursalAndMoney(idSucursal, moneda);
        }

        public OrdenPago GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(OrdenPago value)
        {
            _repository.Insert(value);
        }

        public void Update(int id, OrdenPago value)
        {
            _repository.Update(id, value);
        }
    }
}
