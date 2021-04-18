using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class CanalEnvoi
    {
        public CanalEnvoi()
        {
            Campagnes = new HashSet<Campagne>();
        }

        public int Id { get; set; }
        public string Titre { get; set; }
        public string Code { get; set; }
        public bool? Etat { get; set; }
        public int? IdConatctCanal { get; set; }

        public virtual ContactCanal IdConatctCanalNavigation { get; set; }
        public virtual ICollection<Campagne> Campagnes { get; set; }
    }
}
