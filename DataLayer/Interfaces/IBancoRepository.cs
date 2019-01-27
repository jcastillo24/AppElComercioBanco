using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IBancoRepository
    {
        IEnumerable<Banco> GetAll();
        Banco GetById(int id);
        void Insert(Banco value);
        void Update(int id, Banco value);
        void Delete(int id);

    }
}
