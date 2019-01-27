using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface ISucursalBusiness
    {
        IEnumerable<Sucursal> GetAll();
        IEnumerable<Sucursal> GetAllByIdBanco(int idBanco);
        Sucursal GetById(int id);
        void Insert(Sucursal value);
        void Update(int id, Sucursal value);
        void Delete(int id);

    }
}
