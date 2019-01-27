using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationElComercio.Models
{
    public class Banco
    {
        [DisplayName("Banco")]
        public int idbanco { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime fecharegistro { get; set; }
    }
}
