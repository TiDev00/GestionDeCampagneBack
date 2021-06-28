using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Modele


    {

        public Modele()
        {
            ModeleCampagnes = new HashSet<ModeleCampagne>();
            
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le libellé est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le libellé doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Libelle { get; set; }
        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Contenu { get; set; }
        public bool Statut { get; set; }
        [Required(ErrorMessage = "L'entité est obligatoire")]
        public int IdEntite { get; set; }

        [Required(ErrorMessage = "Le canal d'envoi est obligatoire")]
        public int IdCanalEnvoi { get; set; }


        [ForeignKey("IdCanalEnvoi")]
        public virtual CanalEnvoi IdCanalEnvoiNavigation { get; set; }
        public virtual ICollection<ModeleCampagne> ModeleCampagnes { get; set; }
    }
}
