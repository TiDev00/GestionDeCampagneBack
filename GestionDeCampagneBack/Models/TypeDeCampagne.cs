using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GestionDeCampagneBack.Models
{

    public partial class TypeDeCampagne
    {
        public TypeDeCampagne()
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
