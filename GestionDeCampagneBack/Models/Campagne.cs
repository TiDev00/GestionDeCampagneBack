using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Campagne
    {

        public Campagne()
        {
            ListeDffCampagnes = new HashSet<ListeDffCampagne>();
            ModeleCampagnes = new HashSet<ModeleCampagne>();
            SuiviCampagneCampagnes = new HashSet<SuiviCampagneCampagne>();
            InfosMessageCampagnes = new HashSet<InfosMessageCampagne>();

        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [StringLength(200, MinimumLength = 2,
        ErrorMessage = "Le titre doit comporter au minimum 2 caractères et au maximum 200 caractères")]
        [DataType(DataType.Text)]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le code est obligatoire")]
        [StringLength(50, MinimumLength = 2,
        ErrorMessage = "Le code doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Code { get; set; }


        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // "form-control default-date-picker" 
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateDeDebut { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateDeFin { get; set; }

        public bool Etat { get; set; }

 
        public bool Statut { get; set; }

        [Required(ErrorMessage = "L'utilisateur est obligatoire")]
        public int IdUtilisateur { get; set; }

        [Required(ErrorMessage = "La règle d'envoie est obligatoire")]
        public int IdRegleEnvoi { get; set; }

        [Required(ErrorMessage = "Le niveau de visibilité est obligatoire")]
        public int IdNiveauVisibilite { get; set; }

        [Required(ErrorMessage = "Le type de campagne est obligatoire")]
        public int IdTypeCampagne { get; set; }

        [Required(ErrorMessage = "La categorie est obligatoire")]
        public int IdCategorie { get; set; }

        [Required(ErrorMessage = "L'entité est obligatoire")]
        public int IdEntite { get; set; }

        [ForeignKey("IdNiveauVisibilite")]
        public virtual NiveauDeVisibilite IdNiveauVisibiliteNavigation { get; set; }

        [ForeignKey("IdRegleEnvoi")]
        public virtual RegleDEnvoi IdRegleEnvoiNavigation { get; set; }

        [ForeignKey("IdTypeCampagne")]
        public virtual TypeDeCampagne IdTypeCampagneNavigation { get; set; }

        [ForeignKey("IdCategorie")]
        public virtual Categorie IdCategorieNavigation { get; set; }

        [ForeignKey("IdUtilisateur")]
        public virtual Utilisateur IdUtilisateurNavigation { get; set; }

        public virtual ICollection<ListeDffCampagne> ListeDffCampagnes { get; set; }

        public virtual ICollection<ModeleCampagne> ModeleCampagnes { get; set; }

        public virtual ICollection<SuiviCampagneCampagne> SuiviCampagneCampagnes { get; set; }

        public virtual ICollection<InfosMessageCampagne> InfosMessageCampagnes { get; set; }

    }
}
