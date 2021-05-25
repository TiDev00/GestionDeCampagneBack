using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class SuiviCampagneService : ISuiviCampagne
    {
        private DbcontextGC _dbcontextGC;

        public SuiviCampagneService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddSuiviCampagne(SuiviCampagne SuiviCampagne)
        {
            if (SuiviCampagne == null)
            {
                throw new ArgumentNullException(nameof(SuiviCampagne));

            }

            _dbcontextGC.SuiviCampagnes.Add(SuiviCampagne);
        }

        public void DeleteSuiviCampagne(SuiviCampagne SuiviCampagne)
        {
            if (SuiviCampagne == null)
            {
                throw new ArgumentNullException(nameof(SuiviCampagne));

            }
            _dbcontextGC.SuiviCampagnes.Remove(SuiviCampagne);
            // _dbcontextGC.SuiviCampagnes.Remove(SuiviCampagne);

        }


        public SuiviCampagne EditSuiviCampagne(SuiviCampagne SuiviCampagne, int id)
        {
            var suiviCampagne = _dbcontextGC.SuiviCampagnes.Find(id);
            SuiviCampagne.Id = SuiviCampagne.Id;
            return SuiviCampagne;
        }

        public SuiviCampagne GetSuiviCampagneById(int id)
        {
            var value = _dbcontextGC.SuiviCampagnes.Find(id);
            return value;
        }



        public List<SuiviCampagne> GetSuiviCampagnes()
        {
            return _dbcontextGC.SuiviCampagnes.ToList();
        }
        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }

        SuiviCampagne ISuiviCampagne.GetSuiviCampagneById(int id)
        {
            throw new NotImplementedException();
        }

        List<SuiviCampagne> ISuiviCampagne.GetSuiviCampagnes()
        {
            throw new NotImplementedException();
        }
    }
}
