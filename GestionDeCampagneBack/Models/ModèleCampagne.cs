using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class ModèleCampagne
    {
        public int? IdCampagne { get; set; }
        public int? IdModèle { get; set; }

        public virtual Campagne IdCampagneNavigation { get; set; }
        public virtual Modèle IdModèleNavigation { get; set; }
    }
}
