using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Models
{
    public class Entite
    {
        public Entite()
        {
            Utilisateurs = new HashSet<Utilisateur>();

        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le libelle est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le titre doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Libelle { get; set; }
        public string Activite { get; set; }


        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }



    }
}
