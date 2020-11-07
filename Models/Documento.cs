using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Documento
    {
        [Key]
        public string id_documento { get; set; }
        public string documento { get; set; }
    }
}
