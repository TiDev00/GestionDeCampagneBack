using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class EntiteService : IEntite
    {
        private DbcontextGC _dbcontextGC;

        public EntiteService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }

        public void AddEntite(Entite Entite)
        {
            if (Entite  == null)
            {
                throw new ArgumentNullException(nameof(Entite));

            }
            _dbcontextGC.Entites.Add(Entite);
        }

        public void DeleteEntite(Entite Entite)
        {
            if (Entite == null)
            {
                throw new ArgumentNullException(nameof(Entite));

            }
            _dbcontextGC.Entites.Remove(Entite);
        }

        public Entite EditEntite(Entite Entite, int id)
        {
            var ent = _dbcontextGC.Entites.Find(id);
            ent.Libelle = Entite.Libelle;
            ent.Activite = Entite.Activite;
            return ent;
        }

        public Entite GetEntiteById(int id)
        {
            var entite = _dbcontextGC.Entites.Find(id);
            return entite;
        }

        public List<Entite> GetEntites(int id)
        {
            return _dbcontextGC.Entites.ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
