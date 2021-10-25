using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    [Index(nameof(Matricule), IsUnique = true)]

    public partial class Contact
    {
        public Contact()
        {
            ContactCanals = new HashSet<ContactCanal>();
            ContactListeDiffusions = new HashSet<ContactListeDiffusion>();
            SuiviCampagnes = new HashSet<SuiviCampagne>();
            Variables = new HashSet<Variable>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(200, MinimumLength = 2,
        ErrorMessage = "Le nom doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prenom est obligatoire")]
        [StringLength(200, MinimumLength = 2,
        ErrorMessage = "Le prenom doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Prenom { get; set; }

        public string Matricule { get; set; }

        public string Adresse { get; set; }

        public bool Etat { get; set; }


        public bool Statut { get; set; }
        public string Pays { get; set; }

        [NotMapped]
        public string NomComplet => Prenom + " " + Nom;

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateDeNaissance { get; set; }

        [Required(ErrorMessage = "Le sexe est obligatoire")]
        public string Sexe { get; set; }
        public string Situation { get; set; }
        public string Profession { get; set; }

        [Required(ErrorMessage = "Le niveau de visibilité est obligatoire")]
        public int IdNiveauVisibilite { get; set; }
        [ForeignKey("IdNiveauVisibilite")]
        public virtual NiveauDeVisibilite IdNiveauVisibiliteNavigation { get; set; }

        [Required(ErrorMessage = "L'entité est obligatoire")]
        public int IdEntite { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Utilisateur IdUserNavigation { get; set; }
        public virtual ICollection<ContactCanal> ContactCanals { get; set; }
        public virtual ICollection<ContactListeDiffusion> ContactListeDiffusions { get; set; }
        public virtual ICollection<SuiviCampagne> SuiviCampagnes { get; set; }
        public virtual ICollection<Variable> Variables { get; set; }
    }
}
