using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class CanalEnvoi
    {
        public CanalEnvoi()
        {
            Modeles = new HashSet<Modele>();
            ContactCanals = new HashSet<ContactCanal>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [StringLength(500, MinimumLength = 2,
        ErrorMessage = "Le titre doit comporter au minimum 2 caractères et au maximum 500 caractères")]
        [DataType(DataType.Text)]
        public string Titre { get; set; }

      
        [DataType(DataType.MultilineText)]

        public string Description { get; set; }

        public string Code { get; set; }

 
        public bool Etat { get; set; }
        [Required(ErrorMessage = "L'entité est obligatoire")]

        public virtual ICollection<Modele> Modeles { get; set; }
        public virtual ICollection<ContactCanal> ContactCanals { get; set; }
    }
}
