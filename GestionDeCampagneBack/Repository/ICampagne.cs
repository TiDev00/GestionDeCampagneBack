using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
   public interface ICampagne
    {
        bool SaveChanges();
        List<Campagne> GetCampagnes(int id);

        Campagne GetCampagneById(int id);

        Campagne GetCampagneByCode(string code);

        void SendMail(string email,string body);

        void AddCampagne(Campagne Campagne);

        void DeleteCampagne(Campagne Campagne);

        Campagne EditCampagne(Campagne Campagne, int id);
    }
}
