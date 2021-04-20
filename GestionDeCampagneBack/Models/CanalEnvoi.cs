using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    [Index(nameof(Titre), IsUnique = true)]
    [Index(nameof(Code), IsUnique = true)]
    public partial class CanalEnvoi
    {
        public CanalEnvoi()
        {
            Campagnes = new HashSet<Campagne>();
            ContactCanals = new HashSet<ContactCanal>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le titre doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Titre { get; set; }

        [Required(ErrorMessage = "Le code est obligatoire")]
        [StringLength(50, MinimumLength = 2,
        ErrorMessage = "Le code doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Code { get; set; }

 
        public bool Etat { get; set; }

        public virtual ICollection<Campagne> Campagnes { get; set; }
        public virtual ICollection<ContactCanal> ContactCanals { get; set; }
    }
}
