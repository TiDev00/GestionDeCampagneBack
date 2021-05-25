using System.ComponentModel.DataAnnotations;

namespace GestionDeCampagneBack.Models
{
    public  class Authentification
    {
        [Required(ErrorMessage = "Le login est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le login doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public virtual string Login { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [StringLength(100, ErrorMessage = "Le mot de passe doit comporter au minimum 5 caractères et au maximum 100 caractères", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }
    }
}
