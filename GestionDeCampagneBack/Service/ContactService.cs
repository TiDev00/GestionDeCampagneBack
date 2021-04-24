using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class ContactService : IContact
    {
        private DbcontextGC _dbcontextGC;

        public ContactService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddContact(Contact Contact)
        {
            if (Contact == null)
            {
                throw new ArgumentNullException(nameof(Contact));

            }
            _dbcontextGC.Contacts.Add(Contact);
        }



        public void DeleteContact(Contact Contact)
        {
            if (Contact == null)
            {
                throw new ArgumentNullException(nameof(Contact));

            }
            _dbcontextGC.Contacts.Remove(Contact);
        }

        public Contact EditContact(Contact Contact, int id)
        {
            var contact = _dbcontextGC.Contacts.Find(id);
            contact.Matricule = Contact.Matricule;
            return Contact;

        }


        /*public Contact GetContactByAdresse(string Adresse)
        {
            var Contact = _dbcontextGC.Contacts.FirstOrDefault(r => r.Adresse == Adresse);
            if (Contact != null)
                return Contact;
            else return null;
        }

        public Contact GetContactByDateDeNaissance(DateTime DateNaissance)
        {
            var Contact = _dbcontextGC.Contacts.FirstOrDefault(r => r.DateDeNaissance == DateNaissance);
            if (Contact != null)
                return Contact;
            else return null;
        }*/

        public Contact GetContactById(int id)
        {
            var Contact = _dbcontextGC.Contacts.Find(id);
            return Contact;
        }

        public Contact GetContactByMatricul(string Matricule)
        {
            var Contact = _dbcontextGC.Contacts.FirstOrDefault(r => r.Matricule == Matricule);
            if (Contact != null)
                return Contact;
            else return null;
        }

        /*public Contact GetContactByNom(string Nom)
        {
            var Contact = _dbcontextGC.Contacts.FirstOrDefault(r => r.NomComplet == Nom);
            if (Contact != null)
                return Contact;
            else return null;
        }

        public Contact GetContactByPays(string Pays)
        {
            var Contact = _dbcontextGC.Contacts.FirstOrDefault(r => r.Pays == Pays);
            if (Contact != null)
                return Contact;
            else return null;
        }

        public Contact GetContactByProfession(string Profession)
        {
            var Contact = _dbcontextGC.Contacts.FirstOrDefault(r => r.Profession == Profession);
            if (Contact != null)
                return Contact;
            else return null;
        }

        public Contact GetContactByRegion(string Region)
        {
            var Contact = _dbcontextGC.Contacts.FirstOrDefault(r => r.Region == Region);
            if (Contact != null)
                return Contact;
            else return null;
        }

        public Contact GetContactBySexe(bool Sexe)
        {
            var Contact = _dbcontextGC.Contacts.FirstOrDefault(r => r.Sexe == Sexe);
            if (Contact != null)
                return Contact;
            else return null;
        }

        public Contact GetContactBySituation(bool Situation)
        {
            var Contact = _dbcontextGC.Contacts.FirstOrDefault(r => r.Situation == Situation);
            if (Contact != null)
                return Contact;
            else return null;
        }*/

        public List<Contact> GetContacts()
        {
            return _dbcontextGC.Contacts.ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
