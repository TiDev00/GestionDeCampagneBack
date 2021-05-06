using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface ISuiviCampagne
    {
        bool SaveChanges();
        List<SuiviCampagne> GetSuiviCampagnes();

        SuiviCampagne GetSuiviCampagneById(int id);

        void AddSuiviCampagne(SuiviCampagne SuiviCampagne);

        void DeleteSuiviCampagne(SuiviCampagne SuiviCampagne);

        SuiviCampagne EditSuiviCampagne(SuiviCampagne SuiviCampagne, int id);
    }
}
