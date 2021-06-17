using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface IListeDiffussion
    {

        bool SaveChanges();
        List<ListeDeDiffusion> GetListeDeDiffusions();

        ListeDeDiffusion GetListeDiffusionByID(int id);


        List<Contact> GetContacts();

        List<ContactListeDiffusion> GetContactSelected();
        void AddListeDeDiffusion(ListeDeDiffusion ListeDeDiffusion);

        void DeleteListeDeDiffusion(ListeDeDiffusion ListeDeDiffusion);

        ListeDeDiffusion EditListeDeDiffusion(ListeDeDiffusion ListeDeDiffusion, int Id);
    }
}

