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
            else
            {
                var countval = _dbcontextGC.Modeles.Count();
                if (countval>=1)
                {
                    var maxId = _dbcontextGC.Modeles.Max(p => p.Id);

                    Modele.Code = "MD0000" + (maxId+1).ToString();
                    Modele.Statut = true;
                    _dbcontextGC.Modeles.Add(Modele);
                }
                else
                {
                

                    Modele.Code = "MD00001";
                    Modele.Statut = true;
                    _dbcontextGC.Modeles.Add(Modele);
                }

             
            }
          
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
            var mod = _dbcontextGC.Modeles.Find(id);
  
            mod.Statut = Modele.Statut;
            mod.Libelle = Modele.Libelle;
            mod.Code = Modele.Code;
            mod.Contenu = Modele.Contenu;
            mod.Description = Modele.Description;
            mod.IdEntite = Modele.IdEntite;
            mod.IdCanalEnvoi = Modele.IdCanalEnvoi;
           
            return mod;

        }

        public List<Modele> GetModeleByCanalEnvoi(int idEntite, int idCanal)
        {
            return _dbcontextGC.Modeles.Where(r => r.IdEntite == idEntite && r.IdCanalEnvoi == idCanal).ToList();
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


        public List<Modele> GetModeles(int id)
        {
            return _dbcontextGC.Modeles.Where(r=> r.IdEntite==id).ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
