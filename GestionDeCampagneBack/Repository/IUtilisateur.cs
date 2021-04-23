using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
   public interface IUtilisateur
    {
        bool SaveChanges();
        List<Utilisateur> GetUtilisateurs();

        Utilisateur GetUtilisateurById(int id);

        Utilisateur GetUtilisateurByLogin(string login);

        Utilisateur Authentification(string login, string password);

        Utilisateur GetUtilisateurByEmail(string email);

        void AddUtilisateur(Utilisateur Utilisateur);

        void DeleteUtilisateur(Utilisateur Utilisateur);

        Utilisateur EditUtilisateur(Utilisateur Utilisateur, int id);
    }
}
