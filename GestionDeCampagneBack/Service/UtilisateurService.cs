using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var user = _dbcontextGC.Utilisateurs.Find(id);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(Utilisateur.Password);
            user.Statut = Utilisateur.Statut;
            user.Password = passwordHash;
            user.ConfirmPassword = passwordHash;
            user.Etat = Utilisateur.Etat;
            user.Statut = Utilisateur.Statut;
            user.Nom = Utilisateur.Nom;
            user.Prenom = Utilisateur.Password;
            user.IdRole = Utilisateur.IdRole;
            user.Login = Utilisateur.Login;
            user.Email = Utilisateur.Email;
            user.Telephone = Utilisateur.Telephone;
            return user;
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
            return _dbcontextGC.Utilisateurs.Where(r=> r.Etat ==true).ToList();
        }
        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }


    }

}
