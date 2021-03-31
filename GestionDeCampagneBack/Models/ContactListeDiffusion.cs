using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class ContactListeDiffusion
    {
        public ContactListeDiffusion()
        {
            ListeDeDiffusions = new HashSet<ListeDeDiffusion>();
            NiveauDeVisibilites = new HashSet<NiveauDeVisibilite>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public bool? Etat { get; set; }
        public DateTime? DateDesa { get; set; }
        public string Raison { get; set; }
        public int? IdContact { get; set; }

        public virtual Contact IdContactNavigation { get; set; }
        public virtual ICollection<ListeDeDiffusion> ListeDeDiffusions { get; set; }
        public virtual ICollection<NiveauDeVisibilite> NiveauDeVisibilites { get; set; }
    }
}
