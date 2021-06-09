using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    [Index(nameof(Libelle), IsUnique = true)]
    public partial class NiveauDeVisibilite
    {

        public NiveauDeVisibilite()
        {
            ContactListeDiffusions = new HashSet<ContactListeDiffusion>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le libellé est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le libellé doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Libelle { get; set; }
        public virtual ICollection<ContactListeDiffusion> ContactListeDiffusions { get; set; }


    }
}
