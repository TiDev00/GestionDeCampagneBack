using GestionDeCampagneBack.Models;
using System.Collections.Generic;

/*Contient les fonctions de la classe TypeDeCampagne qui seront 
 * exposé au niveau du controller.
 * Ces fonctions seront implémentées dans la couche service
 */
namespace GestionDeCampagneBack.Repository
{
    public interface ITypeDeCampagne
    {
        //Methode pour sauvegarder les changements dans le context de la bdd
        bool SaveChanges();

        //Methode pour récupérer tous les TypeDeCampagne
        List<TypeDeCampagne> GetTypeDeCampagnes(int id);
        
        //Methode pour recuperer un TypeDeCampagne par id
        TypeDeCampagne GetTypeDeCampagneById(int id);


        //Methode pour ajouter un TypeDeCampagne
        void AddTypeDeCampagne(TypeDeCampagne typeDeCampagne);

        //Methode pour supprimer un TypeDeCampagne
        void DeleteTypeDeCampagne(TypeDeCampagne typeDeCampagne);

        //Methode pour update un TypeDeCampagne
        TypeDeCampagne EditTypeDeCampagne(TypeDeCampagne typeDeCampagne, int id);
    }
}
