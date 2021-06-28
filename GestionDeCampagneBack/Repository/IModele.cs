using GestionDeCampagneBack.Models;
using System.Collections.Generic;


namespace GestionDeCampagneBack.Repository
{
    public interface IModele
    {
        bool SaveChanges();
        List<Modele> GetModeles(int id);

        Modele GetModeleById(int id);
        Modele GetModeleByCode(string code);

        void AddModele(Modele Modele);

        void DeleteModele(Modele Modele);

        Modele EditModele(Modele Modele, int id);
    }
}
