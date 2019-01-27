using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class OrdenPago
    {
        public int Id { get; set; }
        public decimal? Monto { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaPago { get; set; }
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}
