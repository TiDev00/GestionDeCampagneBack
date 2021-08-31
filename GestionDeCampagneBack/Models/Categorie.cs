using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Models
{
    public class Categorie
    {
        public Categorie()
        {
            Campagnes = new HashSet<Campagne>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le libellé est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le libellé doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Libelle { get; set; }
        [Required(ErrorMessage = "L'entité est obligatoire")]
        public int IdEntite { get; set; }

        public virtual ICollection<Campagne> Campagnes { get; set; }
    }
}
