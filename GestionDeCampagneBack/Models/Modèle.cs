﻿using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Modèle
    {
        public int Id { get; set; }
        public string Libellé { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Contenu { get; set; }
        public bool? Statut { get; set; }
    }
}
