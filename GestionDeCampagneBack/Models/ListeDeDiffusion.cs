using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    [Index(nameof(Reference), IsUnique = true)]
    [Index(nameof(Reference), IsUnique = true)]
    public partial class ListeDeDiffusion
    {

        public ListeDeDiffusion()
        {
            ContactListeDiffusions = new HashSet<ContactListeDiffusion>();
            ListeDffCampagnes = new HashSet<ListeDffCampagne>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le titre doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Titre { get; set; }

        /*[Required(ErrorMessage = "La référence est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "La référence doit comporter au minimum 2 caractères et au maximum 100 caractères")]*/
        [DataType(DataType.Text)]
        public string Reference { get; set; }

        public bool Etat { get; set; }

        public bool Statut { get; set; }

        public virtual ICollection<ContactListeDiffusion> ContactListeDiffusions { get; set; }
        public virtual ICollection<ListeDffCampagne> ListeDffCampagnes { get; set; }
    }
}
