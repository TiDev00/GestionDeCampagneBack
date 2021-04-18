﻿using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class ListeDeDiffusion
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Reference { get; set; }
        public bool? Etat { get; set; }
        public bool? Statut { get; set; }
        public int? IdContactListeDiffusion { get; set; }

        public virtual ContactListeDiffusion IdContactListeDiffusionNavigation { get; set; }
    }
}
