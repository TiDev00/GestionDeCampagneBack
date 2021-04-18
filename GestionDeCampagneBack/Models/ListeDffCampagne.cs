using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class ListeDffCampagne
    {
        public int? IdCampagne { get; set; }
        public int? IdListe { get; set; }

        public virtual Campagne IdCampagneNavigation { get; set; }
        public virtual ListeDeDiffusion IdListeNavigation { get; set; }
    }
}
