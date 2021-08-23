using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            else
            {
                var countval = _dbcontextGC.CanalEnvois.Count();
                if (countval >= 1)
                {
                    var maxId = _dbcontextGC.CanalEnvois.Max(p => p.Id);

                    CanalEnvoi.Code = "CE0000" + (maxId + 1).ToString();
                    CanalEnvoi.Etat = true;

                    _dbcontextGC.CanalEnvois.Add(CanalEnvoi);
                }
                else
                {


                    CanalEnvoi.Code = "CE00001";
                    CanalEnvoi.Etat = true;
                    _dbcontextGC.CanalEnvois.Add(CanalEnvoi);
                }


            }

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
            var canal = _dbcontextGC.CanalEnvois.Find(id);
            canal.Code = CanalEnvoi.Code;
            canal.Description = CanalEnvoi.Description;
            canal.Etat = CanalEnvoi.Etat;
            canal.Titre = CanalEnvoi.Titre;
            return canal;

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


        public List<CanalEnvoi> GetCanalEnvois(int id)
        {
            return _dbcontextGC.CanalEnvois.ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
