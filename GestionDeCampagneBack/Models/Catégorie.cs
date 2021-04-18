using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Catégorie
    {
        public Catégorie()
        {
            Campagnes = new HashSet<Campagne>();
        }

        public int Id { get; set; }
        public string Libellé { get; set; }

        public virtual ICollection<Campagne> Campagnes { get; set; }
    }
}
