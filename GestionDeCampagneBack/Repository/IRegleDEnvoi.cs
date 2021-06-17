using GestionDeCampagneBack.Models;
using System.Collections.Generic;

/*Contient les fonctions de la classe RegleDEnvoi qui seront 
 * exposé au niveau du controller.
 * Ces fonctions seront implémentées dans la couche service
 */
namespace GestionDeCampagneBack.Repository
{
    public interface IRegleDEnvoi
    {
       //Methode pour sauvegarder les changements dans le context de la bdd
        bool SaveChanges();

        //Methode pour récupérer toutes les RegleDEnvoi
        List<RegleDEnvoi> GetRegleDEnvois();

        //Methode pour récuperer une RegleDEnvoi a partir de son id
        RegleDEnvoi GetRegleDEnvoiById(int id);

        //Methode pour ajouter une RegleDEnvoi
        void AddRegleDEnvoi(RegleDEnvoi regleDEnvoi);

        //Methode pour supprimer une RegleDEnvoi
        void DeleteRegleDEnvoi(RegleDEnvoi regleDEnvoi);

        //Methode pour update une RegleDEnvoi
        RegleDEnvoi EditRegleDEnvoi(RegleDEnvoi regleDEnvoi, int id);
    }
}
