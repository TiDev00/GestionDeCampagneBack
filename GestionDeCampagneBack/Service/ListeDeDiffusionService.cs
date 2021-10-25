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
            Random rnd = new Random();
            if (ListeDeDiffusion == null)
            {
                throw new ArgumentNullException(nameof(ListeDeDiffusion));

            }
            else
            {
                var countval = _dbcontextGC.ListeDeDiffusions.Count();
                if (countval >= 1)
                {
                    var maxId = _dbcontextGC.ListeDeDiffusions.Max(p => p.Id);
                    int card = rnd.Next(10000, 99999);

                    ListeDeDiffusion.Reference = "RE0000" + card + (maxId + 1).ToString();
                    ListeDeDiffusion.Etat = true;
                    ListeDeDiffusion.Statut = true;

                    _dbcontextGC.ListeDeDiffusions.Add(ListeDeDiffusion);
                }
                else
                {
                    ListeDeDiffusion.Reference = "RE00001";
                    ListeDeDiffusion.Etat = true;
                    ListeDeDiffusion.Statut = true;
                    _dbcontextGC.ListeDeDiffusions.Add(ListeDeDiffusion);
                }
            }
        }

        public void DeleteListeDiffusion(ListeDeDiffusion ListeDeDiffusion)
        {
            if (ListeDeDiffusion == null)
            {
                throw new ArgumentNullException(nameof(ListeDeDiffusion));
            }
            _dbcontextGC.ListeDeDiffusions.Remove(ListeDeDiffusion);
        }

        public ListeDeDiffusion EditListeDiffusion(ListeDeDiffusion ListeDeDiffusion, int id)
        {
            var listeDiffusion = _dbcontextGC.ListeDeDiffusions.Find(id);
            listeDiffusion.Titre = ListeDeDiffusion.Titre;
            listeDiffusion.Etat = ListeDeDiffusion.Etat;
            listeDiffusion.IdEntite = ListeDeDiffusion.IdEntite;
            listeDiffusion.Reference = ListeDeDiffusion.Reference;
            listeDiffusion.Statut = ListeDeDiffusion.Statut;
            listeDiffusion.IdNiveauVisibilite = ListeDeDiffusion.IdNiveauVisibilite;
            return listeDiffusion;

        }


        public ListeDeDiffusion ChangeDonnees(ListeDeDiffusion ListeDeDiffusion, int id)
        {
            var listeDiffusion = _dbcontextGC.ListeDeDiffusions.Find(id);
            listeDiffusion.Titre = ListeDeDiffusion.Titre;
            listeDiffusion.IdEntite = ListeDeDiffusion.IdEntite;
            listeDiffusion.IdNiveauVisibilite = ListeDeDiffusion.IdNiveauVisibilite;
            return listeDiffusion;

        }



        
        public List<ListeDeDiffusion> GetListeDiffusion(int id)
        {
            return _dbcontextGC.ListeDeDiffusions.Where(r => r.Etat == true && r.IdEntite == id).ToList();
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
