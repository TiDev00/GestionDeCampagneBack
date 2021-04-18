using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class SuiviCampagne
    {
        public SuiviCampagne()
        {
            SuiviCampagneCampagnes = new HashSet<SuiviCampagneCampagne>();
        }

        public int Id { get; set; }
        public DateTime? DateEnvoi { get; set; }
        public DateTime? DateReact { get; set; }
        public bool? Reaction { get; set; }
        public string Contenu { get; set; }
        public bool? Statut { get; set; }
        public int? NombreDeTentative { get; set; }
        public int? IdContact { get; set; }

        public virtual Contact IdContactNavigation { get; set; }
        public virtual ICollection<SuiviCampagneCampagne> SuiviCampagneCampagnes { get; set; }
    }
}
