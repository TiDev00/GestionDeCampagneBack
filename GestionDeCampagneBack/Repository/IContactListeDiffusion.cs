using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface IContactListeDiffusion
    {
        bool SaveChanges();
        List<ContactListeDiffusion> GetContactListeDeDiffusions();

        ContactListeDiffusion GetContactListeDiffusionByID(int id);


        List<Contact> GetContacts();

        void AddContactListeDeDiffusion(ContactListeDiffusion ContactListeDiffusion);

        void DeleteContactListeDeDiffusion(ContactListeDiffusion ContactListeDiffusion);

        ContactListeDiffusion EditContactListeDeDiffusion(ContactListeDiffusion ContactListeDiffusion, int Id);
    }
}
