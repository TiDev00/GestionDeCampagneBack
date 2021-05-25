using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface INiveauDeVisibilite
    {
        bool SaveChanges();
        List<NiveauDeVisibilite> GetNiveauDeVisibilites();

        NiveauDeVisibilite GetNiveauDeVisibiliteById(int id);

        NiveauDeVisibilite GetNiveauDeVisibiliteByLibelle(string libelle);

        void AddNiveauDeVisibilite(NiveauDeVisibilite NiveauDeVisibilite);

        void DeleteNiveauDeVisibilite(NiveauDeVisibilite NiveauDeVisibilite);

        NiveauDeVisibilite EditNiveauDeVisibilite(NiveauDeVisibilite NiveauDeVisibilite, int id);
    }
}
