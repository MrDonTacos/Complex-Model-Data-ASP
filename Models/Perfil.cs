using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolpractice.Models
{
    public class Perfil
    {
        [Key]
        public string id_perfil { get; set; }
        public string perfil { get; set; }
    }
}
