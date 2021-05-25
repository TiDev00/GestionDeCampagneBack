using GestionDeCampagneBack.Models;
using System.Collections.Generic;


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
