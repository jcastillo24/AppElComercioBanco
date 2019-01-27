using BusinessLayer.Interfaces;
using DataLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class BancoBusiness : IBancoBusiness
    {
        private readonly IBancoRepository _repository;
        public BancoBusiness(IBancoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Banco> GetAll()
        {
            return _repository.GetAll();
        }
        public Banco GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Insert(Banco value)
        {
            _repository.Insert(value);
        }
        public void Update(int id, Banco value)
        {
            _repository.Update(id, value);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

    }
}
