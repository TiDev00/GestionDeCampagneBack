using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Role
    {
        public Role()
        {
            Utilisateurs = new HashSet<Utilisateur>();
        }

        public int Id { get; set; }
        public string Libellé { get; set; }

        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
