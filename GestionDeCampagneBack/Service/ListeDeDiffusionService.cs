using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class ListeDeDiffusionService : IListeDeDiffusion
    {
        private DbcontextGC _dbcontextGC;

        public ListeDeDiffusionService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddListeDiffusion(ListeDeDiffusion ListeDeDiffusion)
        {
            if (ListeDeDiffusion == null)
            {
                throw new ArgumentNullException(nameof(ListeDeDiffusion));

            }
            _dbcontextGC.ListeDeDiffusions.Add(ListeDeDiffusion);
        }

        public void DeleteListeDiffusion(ListeDeDiffusion ListeDeDiffusion)
        {
            if(ListeDeDiffusion == null)
            {
                throw new ArgumentNullException(nameof(ListeDeDiffusion));
            }
            _dbcontextGC.ListeDeDiffusions.Remove(ListeDeDiffusion);
        }

        public ListeDeDiffusion EditListeDiffusion(ListeDeDiffusion ListeDeDiffusion, int id)
        {
            var listeDiffusion = _dbcontextGC.ListeDeDiffusions.Find(id);
            listeDiffusion.Titre = ListeDeDiffusion.Titre;
            return listeDiffusion;
            
        }

        public List<ListeDeDiffusion> GetListeDiffusion()
        {
            return _dbcontextGC.ListeDeDiffusions.ToList();
        }

        public ListeDeDiffusion GetListeDiffusionById(int id)
        {
            var listeDiffusion = _dbcontextGC.ListeDeDiffusions.Find(id);
            return listeDiffusion;
        }

        public ListeDeDiffusion GetListeDiffusionByReference(string reference)
        {
            var listeDiffuion = _dbcontextGC.ListeDeDiffusions.FirstOrDefault(r => r.Reference == reference);
            if (listeDiffuion != null)
                return listeDiffuion;
            else return null;
        }

        public ListeDeDiffusion GetListeDiffusionByTitre(string titre)
        {
            var listeDiffuion = _dbcontextGC.ListeDeDiffusions.FirstOrDefault(r => r.Titre == titre);
            if (listeDiffuion != null)
                return listeDiffuion;
            else return null;
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
