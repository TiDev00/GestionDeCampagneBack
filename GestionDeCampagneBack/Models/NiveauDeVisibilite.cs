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
            ContactListeDiffusions = new HashSet<ContactListeDiffusion>();
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string Libellé { get; set; }

        public virtual ICollection<Campagne> Campagnes { get; set; }
        public virtual ICollection<ContactListeDiffusion> ContactListeDiffusions { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
