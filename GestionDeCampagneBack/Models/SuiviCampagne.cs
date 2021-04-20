using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class SuiviCampagne
    {

        public SuiviCampagne()
        {
            SuiviCampagneCampagnes = new HashSet<SuiviCampagneCampagne>();

        }
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateEnvoi { get; set; }

        [DataType(DataType.MultilineText)]
        public string Contenu { get; set; }
        public bool Statut { get; set; }
        public int? NombreDeTentative { get; set; }

        [Required(ErrorMessage = "Le contact est obligatoire")]
        public int IdContact { get; set; }
        [ForeignKey("IdContact")]
        public virtual Contact IdContactNavigation { get; set; }

        public virtual ICollection<SuiviCampagneCampagne> SuiviCampagneCampagnes { get; set; }


    }
}
