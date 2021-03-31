using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class ContactCanal
    {
        public ContactCanal()
        {
            CanalEnvois = new HashSet<CanalEnvoi>();
        }

        public int Id { get; set; }
        public string Lien { get; set; }
        public bool? Etat { get; set; }
        public DateTime? DateDesa { get; set; }
        public string Raison { get; set; }
        public int? IdContact { get; set; }

        public virtual Contact IdContactNavigation { get; set; }
        public virtual ICollection<CanalEnvoi> CanalEnvois { get; set; }
    }
}
