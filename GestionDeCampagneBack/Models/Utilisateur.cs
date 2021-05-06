using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    [Index(nameof(Login), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Campagnes = new HashSet<Campagne>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le nom doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string NomComplet { get; set; }

        [Required(ErrorMessage = "l'email est obligatoire")]
        [StringLength(50, ErrorMessage = "L'email doit comporter au minimum 5 caractères et au maximum 50 caractères", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Doit être un e-mail valide")]
       
        public string Email { get; set; }

        [Required(ErrorMessage = "Le login est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le login doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

      
        [DataType(DataType.Password)]
        public string Password { get; set; }


       
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get ;  set; }


        public bool Etat { get; set; }

      
        public bool Statut { get; set; }

        public bool Ischange { get; set; }

        [Required(ErrorMessage = "Le role est obligatoire")]

        public int IdRole { get; set; }
        [ForeignKey("IdRole")]
        public virtual Role IdRoleNavigation { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire")]
        [StringLength(100, MinimumLength = 7,
         ErrorMessage = "Le numéro de téléphone doit comporter au minimum 7 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Telephone { get; set; }
        public virtual ICollection<Campagne> Campagnes { get; set; }
    }
}
