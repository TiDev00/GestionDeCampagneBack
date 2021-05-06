using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class NiveauDeVisibiliteService : INiveauDeVisibilite
    {
        private DbcontextGC _dbcontextGC;

        public NiveauDeVisibiliteService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddNiveauDeVisibilite(NiveauDeVisibilite NiveauDeVisibilite)
        {
            if (NiveauDeVisibilite == null)
            {
                throw new ArgumentNullException(nameof(NiveauDeVisibilite));

            }
            _dbcontextGC.NiveauDeVisibilites.Add(NiveauDeVisibilite);
        }


        public void DeleteNiveauDeVisibilite(NiveauDeVisibilite NiveauDeVisibilite)
        {
            if (NiveauDeVisibilite == null)
            {
                throw new ArgumentNullException(nameof(NiveauDeVisibilite));

            }
            _dbcontextGC.NiveauDeVisibilites.Remove(NiveauDeVisibilite);
            // _dbcontextGC.NiveauDeVisibilites.Remove(NiveauDeVisibilite);

        }


        public NiveauDeVisibilite EditNiveauDeVisibilite(NiveauDeVisibilite NiveauDeVisibilite, int id)
        {
            var niveauDeVisibilite = _dbcontextGC.NiveauDeVisibilites.Find(id);
            niveauDeVisibilite.Libelle = NiveauDeVisibilite.Libelle;
            return niveauDeVisibilite;
        }


        public NiveauDeVisibilite GetNiveauDeVisibiliteById(int id)
        {
            var value = _dbcontextGC.NiveauDeVisibilites.Find(id);
            return value;
        }

        public NiveauDeVisibilite GetNiveauDeVisibiliteByLibelle(string libelle)
        {

            var NiveauDeVisibilite = _dbcontextGC.NiveauDeVisibilites.FirstOrDefault(r => r.Libelle == libelle);
            if (NiveauDeVisibilite != null)
                return NiveauDeVisibilite;
            else return null;
        }

        public List<NiveauDeVisibilite> GetNiveauDeVisibilites()
        {
            return _dbcontextGC.NiveauDeVisibilites.ToList();
        }
        public bool SaveChanges()
        {

            return (_dbcontextGC.SaveChanges() >= 0);

        }

    }
}
