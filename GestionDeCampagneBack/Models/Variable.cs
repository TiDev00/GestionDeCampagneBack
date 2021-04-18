using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Variable
    {
        public int Id { get; set; }
        public byte[] NomAffichage { get; set; }
        public string NomTechnique { get; set; }
        public string Type { get; set; }
        public int? Valeur { get; set; }
        public int? TailleMax { get; set; }
        public int? IdContact { get; set; }

        public virtual Contact IdContactNavigation { get; set; }
    }
}
