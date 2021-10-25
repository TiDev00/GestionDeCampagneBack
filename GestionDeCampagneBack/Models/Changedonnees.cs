using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeCampagneBack.Models
{
    public class Changedonnees
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, MinimumLength = 2,
         ErrorMessage = "Le nom doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prenom est obligatoire")]
        [StringLength(100, MinimumLength = 2,
         ErrorMessage = "Le prenom doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "l'email est obligatoire")]
        [StringLength(50, ErrorMessage = "L'email doit comporter au minimum 5 caractères et au maximum 50 caractères", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Doit être un e-mail valide")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Le login est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le login doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Le role est obligatoire")]
        public int IdRole { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire")]
        [StringLength(100, MinimumLength = 7,
         ErrorMessage = "Le numéro de téléphone doit comporter au minimum 7 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "L'entité est obligatoire")]
        public int IdEntite { get; set; }
    }
}
