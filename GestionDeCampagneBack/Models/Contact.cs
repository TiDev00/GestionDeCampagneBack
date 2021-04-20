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
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le nom doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string NomComplet { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le matricule doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Matricule { get; set; }

        [StringLength(20, MinimumLength = 0)]
        public string Adresse { get; set; }

        public bool Etat { get; set; }

        [Required(ErrorMessage = "Le statut est obligatoire")]
        [StringLength(20, MinimumLength = 2)]
        public bool Statut { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateDeNaissance { get; set; }

        public bool? Sexe { get; set; }
        public bool? Situation { get; set; }
        public string Profession { get; set; }
        [Required(ErrorMessage = "Le niveau de visibilité est obligatoire")]
        public int IdNiveauVisibilite { get; set; }

        [ForeignKey("IdNiveauVisibilite")]
        public virtual NiveauDeVisibilite IdNiveauVisibiliteNavigation { get; set; }
        public virtual ICollection<ContactCanal> ContactCanals { get; set; }
        public virtual ICollection<ContactListeDiffusion> ContactListeDiffusions { get; set; }
        public virtual ICollection<SuiviCampagne> SuiviCampagnes { get; set; }
        public virtual ICollection<Variable> Variables { get; set; }
    }
}
