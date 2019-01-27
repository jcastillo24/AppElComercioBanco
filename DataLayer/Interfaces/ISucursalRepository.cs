using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface ISucursalRepository
    {
        IEnumerable<Sucursal> GetAll();
        Sucursal GetById(int id);
        void Insert(Sucursal value);
        void Update(int id, Sucursal value);
        void Delete(int id);
        IEnumerable<Sucursal> GetAllByIdBanco(int idBanco);
    }
}
