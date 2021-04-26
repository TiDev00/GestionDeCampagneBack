using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

//Implementation des methodes declarees dans le Repository
namespace GestionDeCampagneBack.Service
{
    public class RegleDEnvoiService : IRegleDEnvoi
    {
        //Injection de la classe context pour effectuer les sauvegardes bdd
        private DbcontextGC _dbcontextGC;

        public RegleDEnvoiService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }

        public void AddRegleDEnvoi(RegleDEnvoi regleDEnvoi)
        {
            if (regleDEnvoi == null)
            {
                throw new ArgumentNullException(nameof(regleDEnvoi));

            }
            _dbcontextGC.RegleDEnvois.Add(regleDEnvoi);
        }

        public void DeleteRegleDEnvoi(RegleDEnvoi regleDEnvoi)
        {
            if (regleDEnvoi == null)
            {
                throw new ArgumentNullException(nameof(regleDEnvoi));

            }
            _dbcontextGC.RegleDEnvois.Remove(regleDEnvoi);
        }

        public RegleDEnvoi EditRegleDEnvoi(RegleDEnvoi regleDEnvoi, int id)
        {
            var _regleDEnvoi = _dbcontextGC.RegleDEnvois.Find(id);
            _regleDEnvoi.NombreTentative = regleDEnvoi.NombreTentative;
            _regleDEnvoi.Frequence = regleDEnvoi.Frequence;
            _regleDEnvoi.DateExecution = regleDEnvoi.DateExecution;
            _regleDEnvoi.Expediteur = regleDEnvoi.Expediteur;
            _regleDEnvoi.Recepteur = regleDEnvoi.Recepteur;
            _regleDEnvoi.FuseauHoraire = regleDEnvoi.FuseauHoraire;
            return _regleDEnvoi;
        }

        public RegleDEnvoi GetRegleDEnvoiById(int id)
        {
            var _regleDEnvoi = _dbcontextGC.RegleDEnvois.Find(id);
            return _regleDEnvoi;
        }

        public List<RegleDEnvoi> GetRegleDEnvois()
        {
            return _dbcontextGC.RegleDEnvois.ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
