using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

//Implementation des methodes declarees dans le Repository
namespace GestionDeCampagneBack.Service
{
    public class CategorieService : ICategorie
    {
        //Injection de la classe context pour effectuer les sauvegardes bdd
        private DbcontextGC _dbcontextGC;

        public CategorieService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }

        public void AddCategorie(Categorie categorie)
        {
            if (categorie == null)
            {
                throw new ArgumentNullException(nameof(categorie));

            }
            _dbcontextGC.Categories.Add(categorie);
        }

        public void DeleteCategorie(Categorie categorie)
        {
            if (categorie == null)
            {
                throw new ArgumentNullException(nameof(categorie));

            }
            _dbcontextGC.Categories.Remove(categorie);
        }

        public Categorie EditCategorie(Categorie categorie, int id)
        {
            var _categorie = _dbcontextGC.Categories.Find(id);
            _categorie.Libelle = categorie.Libelle;
            return _categorie;
        }

        public Categorie GetCategorieByLibelle(string libelle)
        {
            var _categorie = _dbcontextGC.Categories.FirstOrDefault(c => c.Libelle == libelle);
            if (_categorie != null)
                return _categorie;
            else return null;
        }

        public List<Categorie> GetCategories()
        {
            return _dbcontextGC.Categories.ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
