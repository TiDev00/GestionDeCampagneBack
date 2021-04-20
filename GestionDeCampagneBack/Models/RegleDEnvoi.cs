using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class RegleDEnvoi
    {
        public RegleDEnvoi()
        {
            Campagnes = new HashSet<Campagne>();
        }

        [Key]
        public int Id { get; set; }
        public int? NombreTentative { get; set; }
        public int? Frequence { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateExecution { get; set; }
        public string Expediteur { get; set; }
        public string Recepteur { get; set; }
        public DateTimeOffset? FuseauHoraire { get; set; }

        public virtual ICollection<Campagne> Campagnes { get; set; }
    }
}
