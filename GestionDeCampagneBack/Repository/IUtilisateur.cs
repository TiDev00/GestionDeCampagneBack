using GestionDeCampagneBack.Models;
using System.Collections.Generic;


namespace GestionDeCampagneBack.Repository
{
   public interface IUtilisateur
    {
        bool SaveChanges();
        List<Utilisateur> GetUtilisateurs(int id);

        Utilisateur GetUtilisateurById(int id);

        Utilisateur GetUtilisateurByLogin(string login);

        void AddUtilisateur(Utilisateur Utilisateur);

        void DeleteUtilisateur(Utilisateur Utilisateur);

        Utilisateur EditUtilisateur(Utilisateur Utilisateur, int id);
    }
}
