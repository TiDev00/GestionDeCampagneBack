using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class ListeDffCampagne
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La campagne est obligatoire")]
        public int IdCampagne { get; set; }

        [ForeignKey("IdCampagne")]
        public virtual Campagne IdCampagneNavigation { get; set; }

        [Required(ErrorMessage = "La liste de diffusion est obligatoire")]
        public int IdListe { get; set; }

        [ForeignKey("IdListe")]
        public virtual ListeDeDiffusion IdListeNavigation { get; set; }

        [Required(ErrorMessage = "L'entité est obligatoire")]
        public int IdEntite { get; set; }
    }
}
