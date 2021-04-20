using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
   public interface IRole
    {
        bool SaveChanges();
        List<Role> GetRoles();

        Role GetRoleById(int id);

        Role GetRoleByLibelle(string libelle);

        void AddRole(Role Role);

        void DeleteRole(Role role);

        Role EditRole(Role Role,int id);
    }
}
