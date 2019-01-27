using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class SucursalBusiness : ISucursalBusiness
    {

        private readonly ISucursalRepository _repository;
        public SucursalBusiness(ISucursalRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Sucursal> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Sucursal> GetAllByIdBanco(int idBanco)
        {
            return _repository.GetAllByIdBanco(idBanco);
        }

        public Sucursal GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Insert(Sucursal value)
        {
            _repository.Insert(value);
        }

        public void Update(int id, Sucursal value)
        {
            _repository.Update(id, value);
        }
    }
}
