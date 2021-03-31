using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Campagne
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? DateDeDébut { get; set; }
        public DateTime? DateDeFin { get; set; }
        public bool? Etat { get; set; }
        public bool? Statut { get; set; }
        public int? IdUtilisateur { get; set; }
        public int? IdRegleEnvoi { get; set; }
        public int? IdNiveauVisibilité { get; set; }
        public int? IdTypeCampagne { get; set; }
        public int? IdCategorie { get; set; }
        public int? IdCanalEnvoi { get; set; }
        public int? IdInfosMessage { get; set; }

        public virtual CanalEnvoi IdCanalEnvoiNavigation { get; set; }
        public virtual Categorie IdCategorieNavigation { get; set; }
        public virtual InfosMessage IdInfosMessageNavigation { get; set; }
        public virtual NiveauDeVisibilite IdNiveauVisibilitéNavigation { get; set; }
        public virtual RegleDEnvoi IdRegleEnvoiNavigation { get; set; }
        public virtual TypeDeCampagne IdTypeCampagneNavigation { get; set; }
        public virtual Utilisateur IdUtilisateurNavigation { get; set; }
    }
}
