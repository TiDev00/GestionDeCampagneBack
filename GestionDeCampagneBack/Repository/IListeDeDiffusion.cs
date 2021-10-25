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
        List<ListeDeDiffusion> GetListeDiffusion(int id);

        ListeDeDiffusion GetListeDiffusionById(int id);

        ListeDeDiffusion GetListeDiffusionByReference(string reference);

        void AddListeDiffusion(ListeDeDiffusion ListeDeDiffusion);

        void DeleteListeDiffusion(ListeDeDiffusion ListeDeDiffusion);

        ListeDeDiffusion EditListeDiffusion(ListeDeDiffusion ListeDeDiffusion, int id);

        ListeDeDiffusion ChangeDonnees(ListeDeDiffusion ListeDeDiffusion, int id);
    }
}