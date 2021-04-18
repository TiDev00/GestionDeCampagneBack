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
            ContactCanals = new HashSet<ContactCanal>();
        }

        public int Id { get; set; }
        public string Titre { get; set; }
        public string Code { get; set; }
        public bool? Etat { get; set; }

        public virtual ICollection<Campagne> Campagnes { get; set; }
        public virtual ICollection<ContactCanal> ContactCanals { get; set; }
    }
}
