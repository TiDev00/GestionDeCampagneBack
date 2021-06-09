using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface IListeDeDiffusion
    {
            
          bool SaveChanges();
        List<ListeDeDiffusion> GetListeDiffusion();

        ListeDeDiffusion GetListeDiffusionById(int id);

        ListeDeDiffusion GetListeDiffusionByTitre(string titre);
        ListeDeDiffusion GetListeDiffusionByReference(string reference);

        void AddListeDiffusion(ListeDeDiffusion ListeDeDiffusion);

        void DeleteListeDiffusion(ListeDeDiffusion ListeDeDiffusion);

        ListeDeDiffusion EditListeDiffusion(ListeDeDiffusion ListeDeDiffusion, int id);
    }
}