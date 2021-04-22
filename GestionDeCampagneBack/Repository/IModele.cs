using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface IModele
    {
        bool SaveChanges();
        List<Modele> GetModeles();

        Modele GetModeleById(int id);

        Modele GetModeleByLibelle(string libelle);
        Modele GetModeleByCode(string code);

        void AddModele(Modele Modele);

        void DeleteModele(Modele Modele);

        Modele EditModele(Modele Modele, int id);
    }
}
