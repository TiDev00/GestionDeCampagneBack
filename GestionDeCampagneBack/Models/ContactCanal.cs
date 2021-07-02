using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{

    public partial class ContactCanal
    {
  
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le canal est obligatoire")]
        [StringLength(200, MinimumLength = 2,
        ErrorMessage = "Le canal doit comporter au minimum 2 caractères et au maximum 200 caractères")]
        [DataType(DataType.Text)]
        public string CanalDuContatct { get; set; }

        [Required(ErrorMessage = "Le lien ou le numero est obligatoire")]
        [StringLength(500, MinimumLength = 2,
        ErrorMessage = "Le lien ou le numero doit comporter au minimum 2 caractères et au maximum 500 caractères")]
        [DataType(DataType.Text)]
        public string Lieuounumero { get; set; }

        public bool Etat { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateDesabonnement { get; set; }
        public string Raison { get; set; }

        [Required(ErrorMessage = "Le contact est obligatoire")]
        public int IdContact { get; set; }
        [ForeignKey("IdContact")]
        public virtual Contact IdContactNavigation { get; set; }

        [Required(ErrorMessage = "Le contact est obligatoire")]
        public int IdCanalEnvoi { get; set; }
        [ForeignKey("IdCanalEnvoi")]
        public virtual CanalEnvoi IdCanalEnvoiNavigation { get; set; }
        [Required(ErrorMessage = "L'entité est obligatoire")]
        public int IdEntite { get; set; }

    }
}
