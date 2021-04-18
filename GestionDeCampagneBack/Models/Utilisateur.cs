using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Campagnes = new HashSet<Campagne>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string MotDePasse { get; set; }
        public bool? Etat { get; set; }
        public bool? Statut { get; set; }
        public int? IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<Campagne> Campagnes { get; set; }
    }
}
