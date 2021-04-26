using GestionDeCampagneBack.Models;
using System.Collections.Generic;

/*Contient les fonctions de la classe Categorie qui seront 
 * exposé au niveau du controller.
 * Ces fonctions seront implémentées dans la couche service
 */
namespace GestionDeCampagneBack.Repository
{
    interface ICategorie
    {
        //Methode pour sauvegarder les changements dans le context de la bdd
        bool SaveChanges();

        //Methode pour récupérer toutes les Categories
        List<Categorie> GetCategories();

        //Methode pour récuperer une Categorie a partir de son libelle
        Categorie GetCategorieByLibelle(string libelle);

        //Methode pour ajouter une Categorie
        void AddCategorie(Categorie categorie);

        //Methode pour supprimer une Categorie
        void DeleteCategorie(Categorie categorie);

        //Methode pour update une Categorie
        Categorie EditCategorie(Categorie categorie, int id);
    }
}
