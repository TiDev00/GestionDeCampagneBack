using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class RoleService : IRole
    {
        private DbcontextGC _dbcontextGC;

        public RoleService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddRole(Role Role)
        {
            if (Role == null)
            {
                throw new ArgumentNullException(nameof(Role));

            }
            _dbcontextGC.Roles.Add(Role);
        }

        public void DeleteRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));

            }
            _dbcontextGC.Roles.Remove(role);
           // _dbcontextGC.Roles.Remove(Role);
              
        }

        public Role EditRole(Role Role,int id)
        {
            var role = _dbcontextGC.Roles.Find(id);
            role.Libelle = Role.Libelle;
            return role;
        }

        public Role GetRoleById(int id)
        {
            var value = _dbcontextGC.Roles.Find(id);
            return value;
        }

        public Role GetRoleByLibelle(string libelle)
        {
 
            var role = _dbcontextGC.Roles.FirstOrDefault(r => r.Libelle == libelle);
            if (role != null)
                return role;
            else return null;
        }

        public List<Role> GetRoles()
        {
            return _dbcontextGC.Roles.ToList();
        }
        public bool SaveChanges()
        {

                return (_dbcontextGC.SaveChanges() >= 0);
           
        }
    }
}
