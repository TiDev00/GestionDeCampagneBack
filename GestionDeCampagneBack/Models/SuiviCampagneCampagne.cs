using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class SuiviCampagneCampagne
    {
        public int? IdCampagne { get; set; }
        public int? IdSuivi { get; set; }

        public virtual Campagne IdCampagneNavigation { get; set; }
        public virtual SuiviCampagne IdSuiviNavigation { get; set; }
    }
}
