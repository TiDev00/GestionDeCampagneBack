using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(Libelle), IsUnique = true)]
    public partial class Modele


    {

        public Modele()
        {
            ModeleCampagnes = new HashSet<ModeleCampagne>();
            
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le libellé est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le libellé doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Libelle { get; set; }

        [Required(ErrorMessage = "Le code est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le code doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Contenu { get; set; }
        public bool Statut { get; set; }

        public virtual ICollection<ModeleCampagne> ModeleCampagnes { get; set; }
    }
}
