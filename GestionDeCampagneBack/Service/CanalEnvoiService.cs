using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class CanalEnvoiService : ICanalEnvoi
    {
        private DbcontextGC _dbcontextGC;

        public CanalEnvoiService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddCanalEnvoi(CanalEnvoi CanalEnvoi)
        {
            if (CanalEnvoi == null)
            {
                throw new ArgumentNullException(nameof(CanalEnvoi));

            }
            _dbcontextGC.CanalEnvois.Add(CanalEnvoi);
        }

        public void DeleteCanalEnvoi(CanalEnvoi CanalEnvoi)
        {
            if (CanalEnvoi == null)
            {
                throw new ArgumentNullException(nameof(CanalEnvoi));

            }
            _dbcontextGC.CanalEnvois.Remove(CanalEnvoi);
        }

        public CanalEnvoi EditCanalEnvoi(CanalEnvoi CanalEnvoi, int id)
        {
            var canalEnvoi = _dbcontextGC.CanalEnvois.Find(id);
            canalEnvoi.Code = CanalEnvoi.Code;
            return canalEnvoi;

        }

        public CanalEnvoi GetCanalEnvoiByCode(string code)
        {
            var canalenvoi = _dbcontextGC.CanalEnvois.FirstOrDefault(r => r.Code == code);
            if (canalenvoi != null)
                return canalenvoi;
            else return null;
        }

        public CanalEnvoi GetCanalEnvoiById(int id)
        {
            var canalEnvoi = _dbcontextGC.CanalEnvois.Find(id);
            return canalEnvoi;
        }

        public CanalEnvoi GetCanalEnvoiByTitre(string titre)
        {
            var canalenvoi = _dbcontextGC.CanalEnvois.FirstOrDefault(r => r.Titre == titre);
            if (canalenvoi != null)
                return canalenvoi;
            else return null;
        }

        public List<CanalEnvoi> GetCanalEnvois()
        {
            return _dbcontextGC.CanalEnvois.ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
