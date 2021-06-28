using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface IEntite
    {
        bool SaveChanges();
        List<Entite> GetEntites(int id);

        Entite GetEntiteById(int id);

        void AddEntite(Entite Entite);

        void DeleteEntite(Entite Entite);

        Entite EditEntite(Entite Entite, int id);
    }
}
