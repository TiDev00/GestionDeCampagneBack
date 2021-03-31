using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Libellé { get; set; }
        public int? IdUtilisateur { get; set; }

        public virtual Utilisateur IdUtilisateurNavigation { get; set; }
    }
}
