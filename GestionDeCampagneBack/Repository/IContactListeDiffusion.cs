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
        List<ContactListeDiffusion> GetContactListeDiffusions();

        ContactListeDiffusion GetContactListeDiffusionById(int id);

        ContactListeDiffusion GetContactListeDiffusionByCode(string Code);

        void AddContactListeDiffusion(ContactListeDiffusion ContactListeDiffusion);

        void DeleteContactListeDiffusion(ContactListeDiffusion ContactListeDiffusion);

        ContactListeDiffusion EditContactListeDiffusion(ContactListeDiffusion ContactListeDiffusion, int id);
    }
}
