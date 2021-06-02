using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Models
{
    public class Changerpassword
    {

        [DataType(DataType.Password)]
        public string Amp { get; set; }

        [DataType(DataType.Password)]
        public string Nmp { get; set; }

        [DataType(DataType.Password)]
        [Compare("Nmp")]
        [NotMapped]
        public string Cnmp { get; set; }

    }
}
