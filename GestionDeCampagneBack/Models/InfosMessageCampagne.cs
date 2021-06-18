using System.ComponentModel.DataAnnotations;


namespace GestionDeCampagneBack.Models
{
    public class InfosMessageCampagne
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La campagne est obligatoire")]
        public int IdCampagne { get; set; }

        public virtual Campagne IdCampagneNavigation { get; set; }

        [Required(ErrorMessage = "L'Infos Message est obligatoire")]
        public int IdInfosMessage { get; set; }

        public virtual InfosMessage IdInfosMessageNavigation { get; set; }
    }
}
