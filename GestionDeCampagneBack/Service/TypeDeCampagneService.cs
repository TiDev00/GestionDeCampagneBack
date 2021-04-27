using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

//Implementation des methodes declarees dans le Repository
namespace GestionDeCampagneBack.Service
{
    public class TypeDeCampagneService : ITypeDeCampagne
    {
        //Injection de la classe context pour effectuer les sauvegardes
        private DbcontextGC _dbcontextGC;

        public TypeDeCampagneService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }

        public void AddTypeDeCampagne(TypeDeCampagne typeDeCampagne)
        {
            if (typeDeCampagne == null)
            {
                throw new ArgumentNullException(nameof(typeDeCampagne));

            }
            _dbcontextGC.TypeDeCampagnes.Add(typeDeCampagne);
        }

        public void DeleteTypeDeCampagne(TypeDeCampagne typeDeCampagne)
        {
            if (typeDeCampagne == null)
            {
                throw new ArgumentNullException(nameof(typeDeCampagne));

            }
            _dbcontextGC.TypeDeCampagnes.Remove(typeDeCampagne);
        }

        public TypeDeCampagne EditTypeDeCampagne(TypeDeCampagne typeDeCampagne, int id)
        {
            var _typeDeCampagne = _dbcontextGC.TypeDeCampagnes.Find(id);
            _typeDeCampagne.Libelle = typeDeCampagne.Libelle;
            return _typeDeCampagne;
        }

        public TypeDeCampagne GetTypeDeCampagneById(int id)
        {
            var _typeDeCampagne = _dbcontextGC.TypeDeCampagnes.Find(id);
            return _typeDeCampagne;
        }
        
        public TypeDeCampagne GetTypeDeCampagneByLibelle(string libelle)
        {
            var _typeDeCampagne = _dbcontextGC.TypeDeCampagnes.FirstOrDefault(t => t.Libelle == libelle);
            if (_typeDeCampagne != null)
                return _typeDeCampagne;
            else return null;
        }

        public List<TypeDeCampagne> GetTypeDeCampagnes()
        {
            return _dbcontextGC.TypeDeCampagnes.ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
