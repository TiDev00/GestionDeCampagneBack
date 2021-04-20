using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{

    public partial class Variable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom de l'affichage est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le nom de l'affichage doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string NomAffichage { get; set; }

        [Required(ErrorMessage = "Le nom technique est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le nom technique doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string NomTechnique { get; set; }
        public string Type { get; set; }
        public int? Valeur { get; set; }
        public int? TailleMax { get; set; }
        public int IdContact { get; set; }
        [ForeignKey("IdContact")]
        public virtual Contact IdContactNavigation { get; set; }
    }
}
