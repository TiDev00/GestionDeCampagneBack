using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    [Index(nameof(Libelle), IsUnique = true)]
    public partial class Role
    {
        public Role()
        {
            Utilisateurs = new HashSet<Utilisateur>();
        
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le libelle est obligatoire")]
        [StringLength(50, MinimumLength = 2,
        ErrorMessage = "Le titre doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Libelle { get; set; }
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }



    }
}
