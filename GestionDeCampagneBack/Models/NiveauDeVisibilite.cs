using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class NiveauDeVisibilite
    {
        public NiveauDeVisibilite()
        {
            Campagnes = new HashSet<Campagne>();
        }

        public int Id { get; set; }
        public string Libellé { get; set; }
        public int? IdConatct { get; set; }
        public int? IdContactListeDiffusion { get; set; }

        public virtual Contact IdConatctNavigation { get; set; }
        public virtual ContactListeDiffusion IdContactListeDiffusionNavigation { get; set; }
        public virtual ICollection<Campagne> Campagnes { get; set; }
    }
}
