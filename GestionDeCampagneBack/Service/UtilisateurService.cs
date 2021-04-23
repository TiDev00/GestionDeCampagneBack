using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class UtilisateurService : IUtilisateur
    {
        private DbcontextGC _dbcontextGC;

        public UtilisateurService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddUtilisateur(Utilisateur Utilisateur)
        {
            if (Utilisateur == null)
            {
                throw new ArgumentNullException(nameof(Utilisateur));

            }

            _dbcontextGC.Utilisateurs.Add(Utilisateur);
        }

        public void DeleteUtilisateur(Utilisateur Utilisateur)
        {
            if (Utilisateur == null)
            {
                throw new ArgumentNullException(nameof(Utilisateur));

            }
            _dbcontextGC.Utilisateurs.Remove(Utilisateur);
            // _dbcontextGC.Utilisateurs.Remove(Utilisateur);

        }

        public Utilisateur EditUtilisateur(Utilisateur Utilisateur, int id)
        {
            var utilisateur = _dbcontextGC.Utilisateurs.Find(id);
            Utilisateur.Statut = true;
            return Utilisateur;
        }

        public Utilisateur GetUtilisateurById(int id)
        {
            var value = _dbcontextGC.Utilisateurs.Find(id);
            return value;
        }

        public Utilisateur GetUtilisateurByLogin(string login)
        {
            var user = _dbcontextGC.Utilisateurs.FirstOrDefault(r => r.Login == login);
            if (user != null)
                return user;
            else return null;
        }

        public Utilisateur GetUtilisateurByEmail(string email)
        {
            var user = _dbcontextGC.Utilisateurs.FirstOrDefault(r => r.Email == email);
            if (user != null)
                return user;
            else return null;
        }

        public List<Utilisateur> GetUtilisateurs()
        {
            return _dbcontextGC.Utilisateurs.ToList();
        }
        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }

        public Utilisateur Authentification(string login, string password)
        {
            var user = _dbcontextGC.Utilisateurs.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
                return user;
            else return null;
        }
    }

}
