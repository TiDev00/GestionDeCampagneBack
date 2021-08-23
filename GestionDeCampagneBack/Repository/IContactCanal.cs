using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface IContactCanal
    {
        bool SaveChanges();
        List<ContactCanal> GetContactCanals(int id);

        ContactCanal GetContactCanalById(int id);

        void AddContactCanal(ContactCanal ContactCanal);

        void DeleteContactCanal(ContactCanal ContactCanal);

        ContactCanal EditContactCanal(ContactCanal ContactCanal, int id);
    }
}
