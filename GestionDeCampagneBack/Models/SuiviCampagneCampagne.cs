using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class SuiviCampagneCampagne
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La campagne est obligatoire")]
        public int IdCampagne { get; set; }

        [Required(ErrorMessage = "Le SuiviCampagne est obligatoire")]
        public int IdSuivi { get; set; }


        public virtual Campagne IdCampagneNavigation { get; set; }

      
        public virtual SuiviCampagne IdSuiviNavigation { get; set; }
    }
}
