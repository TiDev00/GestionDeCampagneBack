using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
   public interface IContactCanalEnvoi
    {
        bool SaveChanges();
        List<ContactCanal> GetContactCanalCanals();

        ContactCanal GetContactCanalById(int Id);

        void AddContactCanal(ContactCanal ContactCanal);

        void DeleteContactCanal(ContactCanal ContactCanal);

        ContactCanal EditContactCanal(ContactCanal ContactCanal, int Id);
    }
}
