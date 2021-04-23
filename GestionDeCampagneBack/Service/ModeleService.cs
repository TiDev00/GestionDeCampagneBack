using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionDeCampagneBack.Service
{
    public class ModeleService : IModele
    {
        private DbcontextGC _dbcontextGC;

        public ModeleService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddModele(Modele Modele)
        {
            if (Modele == null)
            {
                throw new ArgumentNullException(nameof(Modele));

            }
            _dbcontextGC.Modeles.Add(Modele);
        }

  

        public void DeleteModele(Modele Modele)
        {
            if (Modele == null)
            {
                throw new ArgumentNullException(nameof(Modele));

            }
            _dbcontextGC.Modeles.Remove(Modele);
        }

        public Modele EditModele(Modele Modele, int id)
        {
            var modele = _dbcontextGC.Modeles.Find(id);
            modele.Code = Modele.Code;
            return Modele;

        }

        public Modele GetModeleByCode(string code)
        {
            var Modele = _dbcontextGC.Modeles.FirstOrDefault(r => r.Code == code);
            if (Modele != null)
                return Modele;
            else return null;
        }

        public Modele GetModeleById(int id)
        {
            var Modele = _dbcontextGC.Modeles.Find(id);
            return Modele;
        }

        public Modele GetModeleByLibelle(string libelle)
        {
            var Modele = _dbcontextGC.Modeles.FirstOrDefault(r => r.Libelle == libelle);
            if (Modele != null)
                return Modele;
            else return null;
        }

        public List<Modele> GetModeles()
        {
            return _dbcontextGC.Modeles.ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
