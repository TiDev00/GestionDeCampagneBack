using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionDeCampagneBack.Service
{
    public class InfosMessageService : IInfosMessage
    {
        //Injection de la classe context pour effectuer les sauvegardes bdd
        private DbcontextGC _dbcontextGC;

        public InfosMessageService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }

        public void AddInfosMessage(InfosMessage infosMessage)
        {
            if (infosMessage == null)
            {
                throw new ArgumentNullException(nameof(infosMessage));

            }
            _dbcontextGC.InfosMessages.Add(infosMessage);
        }

        public void DeleteInfosMessage(InfosMessage infosMessage)
        {
            if (infosMessage == null)
            {
                throw new ArgumentNullException(nameof(infosMessage));

            }
            _dbcontextGC.InfosMessages.Remove(infosMessage);
        }

        public InfosMessage EditInfosMessage(InfosMessage infosMessage, int id)
        {
            var _infosMessage = _dbcontextGC.InfosMessages.Find(id);
            _infosMessage.MessagePrevu = infosMessage.MessagePrevu;
            _infosMessage.MessageAchemines = infosMessage.MessageAchemines;
            _infosMessage.MessageEnCours = infosMessage.MessageEnCours;
            _infosMessage.MessageErreur = infosMessage.MessageErreur;
            return _infosMessage;
        }

        public InfosMessage GetInfosMessageById(int id)
        {
            var _infosMessage = _dbcontextGC.InfosMessages.Find(id);
            return _infosMessage;
        }


        public List<InfosMessage> GetInfosMessages()
        {
            return _dbcontextGC.InfosMessages.ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
