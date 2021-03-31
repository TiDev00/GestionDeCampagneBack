using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Contact
    {
        public Contact()
        {
            ContactCanals = new HashSet<ContactCanal>();
            ContactListeDiffusions = new HashSet<ContactListeDiffusion>();
            NiveauDeVisibilites = new HashSet<NiveauDeVisibilite>();
            SuiviCampagnes = new HashSet<SuiviCampagne>();
            Variables = new HashSet<Variable>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public bool? Etat { get; set; }
        public bool? Statut { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public DateTime? Anniverssaire { get; set; }
        public decimal? Tel { get; set; }
        public string Email { get; set; }
        public bool? Sexe { get; set; }
        public bool? Situation { get; set; }
        public string Profession { get; set; }

        public virtual ICollection<ContactCanal> ContactCanals { get; set; }
        public virtual ICollection<ContactListeDiffusion> ContactListeDiffusions { get; set; }
        public virtual ICollection<NiveauDeVisibilite> NiveauDeVisibilites { get; set; }
        public virtual ICollection<SuiviCampagne> SuiviCampagnes { get; set; }
        public virtual ICollection<Variable> Variables { get; set; }
    }
}
