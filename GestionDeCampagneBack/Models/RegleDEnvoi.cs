using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class RegleDEnvoi
    {
        public RegleDEnvoi()
        {
            Campagnes = new HashSet<Campagne>();
        }

        public int Id { get; set; }
        public int? NombreTentative { get; set; }
        public int? Frequence { get; set; }
        public DateTime? DateExecution { get; set; }
        public string Expediteur { get; set; }
        public string Recepteur { get; set; }
        public DateTimeOffset? FuseauHoraire { get; set; }

        public virtual ICollection<Campagne> Campagnes { get; set; }
    }
}
