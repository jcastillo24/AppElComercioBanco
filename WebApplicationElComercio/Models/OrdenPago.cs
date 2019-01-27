using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationElComercio.Models
{
    public class OrdenPago
    {
        public int idordenpago { get; set; }
        public Double? monto { get; set; }
        public string moneda { get; set; }
        public string estado { get; set; }

        [Display(Name = "Fecha de Pago")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? fechapago { get; set; }
        [DisplayName("Sucursal")]
        public int idsucursal { get; set; }
        public Sucursal sucursal { get; set; }
    }
}
