using GestionDeCampagneBack.Models;
using System.Collections.Generic;

/*Contient les fonctions de la classe InfosMessage qui seront 
 * exposé au niveau du controller.
 * Ces fonctions seront implémentées dans la couche service
 */

namespace GestionDeCampagneBack.Repository
{
    interface IInfosMessage 
    {
        //Methode pour sauvegarder les changements dans le context de la bdd
        bool SaveChanges();

        //Methode pour récupérer toutes les InfosMessage
        List<InfosMessage> GetInfosMessages();

        //Methode pour récuperer une InfoMessage a partir de son id
        InfosMessage GetInfosMessageById(int id);

        //Methode pour ajouter une InfosMessage
        void AddInfosMessage(InfosMessage infosMessage);

        //Methode pour supprimer une InfosMessage
        void DeleteInfosMessage(InfosMessage infosMessage);

        //Methode pour update une InfosMessage
        InfosMessage EditInfosMessage(InfosMessage infosMessage, int id);
    }
}
