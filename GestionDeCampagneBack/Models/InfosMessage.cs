using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class InfosMessage
    {
        public InfosMessage()
        {
            Campagnes = new HashSet<Campagne>();
        }

        public int Id { get; set; }
        public int? MessagePrevu { get; set; }
        public int? MessageAcheminés { get; set; }
        public int? MessageEnCours { get; set; }
        public int? MessageErreur { get; set; }

        public virtual ICollection<Campagne> Campagnes { get; set; }
    }
}
