using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Models
{
    public class InfosMessageCampagne
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La campagne est obligatoire")]
        public int IdCampagne { get; set; }

        public virtual Campagne IdCampagneNavigation { get; set; }

        [Required(ErrorMessage = "L'Infos Message est obligatoire")]
        public int IdInfosMessage { get; set; }

        public virtual InfosMessage IdInfosMessageNavigation { get; set; }
    }
}
