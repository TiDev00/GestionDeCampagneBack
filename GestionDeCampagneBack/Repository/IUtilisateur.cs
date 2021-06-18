using GestionDeCampagneBack.Models;
using System.Collections.Generic;


namespace GestionDeCampagneBack.Repository
{
   public interface IUtilisateur
    {
        bool SaveChanges();
        List<Utilisateur> GetUtilisateurs();

        Utilisateur GetUtilisateurById(int id);

        Utilisateur GetUtilisateurByLogin(string login);

        Utilisateur GetUtilisateurByEmail(string email);

        void AddUtilisateur(Utilisateur Utilisateur);

        void DeleteUtilisateur(Utilisateur Utilisateur);

        Utilisateur EditUtilisateur(Utilisateur Utilisateur, int id);
    }
}
