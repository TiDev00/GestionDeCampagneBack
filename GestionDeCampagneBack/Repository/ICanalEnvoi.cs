using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
  public  interface ICanalEnvoi
    {
          bool SaveChanges();
        List<CanalEnvoi> GetCanalEnvois();

        CanalEnvoi GetCanalEnvoiById(int id);

        CanalEnvoi GetCanalEnvoiByTitre(string titre);
        CanalEnvoi GetCanalEnvoiByCode(string code);

        void AddCanalEnvoi(CanalEnvoi CanalEnvoi);

        void DeleteCanalEnvoi(CanalEnvoi CanalEnvoi);

        CanalEnvoi EditCanalEnvoi(CanalEnvoi CanalEnvoi,int id);
    }
}
