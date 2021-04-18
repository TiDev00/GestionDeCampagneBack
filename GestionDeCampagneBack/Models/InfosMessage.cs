using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class InfosMessage
    {
        public int Id { get; set; }
        public int? MessagePrevu { get; set; }
        public int? MessageAcheminés { get; set; }
        public int? MessageEnCours { get; set; }
        public int? MessageErreur { get; set; }

        public virtual Campagne IdNavigation { get; set; }
    }
}
