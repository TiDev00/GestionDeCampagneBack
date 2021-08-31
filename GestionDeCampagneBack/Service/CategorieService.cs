using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class CategorieService : ICategorie
    {
        private DbcontextGC _dbcontextGC;

        public CategorieService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }

        public void AddCategorie(Categorie Categorie)
        {
            if (Categorie == null)
            {
                throw new ArgumentNullException(nameof(Categorie));

            }
            _dbcontextGC.Categories.Add(Categorie);
        }

        public void DeleteCategorie(Categorie Categorie)
        {
            if (Categorie == null)
            {
                throw new ArgumentNullException(nameof(Categorie));

            }
            _dbcontextGC.Categories.Remove(Categorie);
        }

        public Categorie EditCategorie(Categorie Categorie, int id)
        {
            var _Categorie = _dbcontextGC.Categories.Find(id);
            _Categorie.Libelle = Categorie.Libelle;
            _Categorie.IdEntite = Categorie.IdEntite;
            return _Categorie;
        }

        public Categorie GetCategorieById(int id)
        {
            var _Categorie = _dbcontextGC.Categories.Find(id);
            return _Categorie;
        }



        public List<Categorie> GetCategories(int id)
        {
            return _dbcontextGC.Categories.Where(r => r.IdEntite == id).ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
