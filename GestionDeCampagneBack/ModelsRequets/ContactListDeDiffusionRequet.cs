using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.ModelsRequets
{
    public class ContactListDeDiffusionRequet
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le Nom doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public virtual string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [StringLength(100, ErrorMessage = "Le Prenom doit comporter au minimum 5 caractères et au maximum 100 caractères", MinimumLength = 5)]
        [DataType(DataType.Text)]
        public virtual string Prenom { get; set; }

        [Required(ErrorMessage = "Le sexe est obligatoire")]
        [StringLength(100, ErrorMessage = "Le Sexe doit comporter au minimum 5 caractères et au maximum 100 caractères", MinimumLength = 5)]
        [DataType(DataType.Text)]
        public virtual string Sexe { get; set; }
    }
}
