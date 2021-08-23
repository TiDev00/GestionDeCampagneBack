﻿using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class ContactListeDiffusion
    {
      
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le code est obligatoire")]
        [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Le code doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public string Code { get; set; }
        public bool Etat { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateDesa { get; set; }
        public string Raison { get; set; }

        [Required(ErrorMessage = "Le contact est obligatoire")]
        public int IdContact { get; set; }

        [ForeignKey("IdContact")]
        public virtual Contact IdContactNavigation { get; set; }

        public int IdListeDiffusion { get; set; }

        [ForeignKey("IdListeDiffusion")]
        public virtual ListeDeDiffusion IdIdListeDiffusionNavigation { get; set; }

        [Required(ErrorMessage = "L'entité est obligatoire")]
        public int IdEntite { get; set; }


    }
}
