using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int BancoId { get; set; }
        public Banco Banco { get; set; }
    }
}
