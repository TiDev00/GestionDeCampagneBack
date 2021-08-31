using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
   public interface ICategorie
    {
        bool SaveChanges();

        //Methode pour récupérer toutes les Categorie
        List<Categorie> GetCategories(int id);

        //Methode pour recuperer une Categorie par id
        Categorie GetCategorieById(int id);


        //Methode pour ajouter une Categorie
        void AddCategorie(Categorie Categorie);

        //Methode pour supprimer une Categorie
        void DeleteCategorie(Categorie Categorie);

        //Methode pour update une Categorie
        Categorie EditCategorie(Categorie Categorie, int id);
    }
}
