using GestionDeCampagneBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Repository
{
    public interface IContact
    {
        bool SaveChanges();
        List<Contact> GetContacts();

        Contact GetContactById(int Id);

        Contact GetContactByMatricul(string Matricule);

        List<ContactCanal> GetContactCanalCanals();

        void AddContact(Contact Contact);

        void DeleteContact(Contact Contact);

        Contact EditContact(Contact Contact, int Id);
    }
}
