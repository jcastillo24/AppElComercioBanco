using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBancoBusiness
    {
        IEnumerable<Banco> GetAll();
        Banco GetById(int id);
        void Insert(Banco value);
        void Update(int id, Banco value);
        void Delete(int id);
        
    }
}
