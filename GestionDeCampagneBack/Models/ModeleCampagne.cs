using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class ModeleCampagne
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La campagne est obligatoire")]
        public int IdCampagne { get; set; }

        [ForeignKey("IdCampagne")]
        public virtual Campagne IdCampagneNavigation { get; set; }

        [Required(ErrorMessage = "Le modèle est obligatoire")]
        public int IdModele { get; set; }

        [ForeignKey("IdModele")]
        public virtual Modele IdModeleNavigation { get; set; }
    }
}
