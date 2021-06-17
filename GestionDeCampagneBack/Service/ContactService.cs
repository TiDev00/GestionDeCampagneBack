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
            else
            {
                var countval = _dbcontextGC.Contacts.Count();
                if (countval >= 1)
                {
                    var maxId = _dbcontextGC.Contacts.Max(p => p.Id);

                    Contact.Matricule = "CT0000" + (maxId + 1).ToString();
                    Contact.Etat = true;
                    Contact.Statut = true;

                    _dbcontextGC.Contacts.Add(Contact);
                }
                else
                {


                    Contact.Matricule = "CT00001";
                    Contact.Etat = true;
                    Contact.Statut = true;
                    _dbcontextGC.Contacts.Add(Contact);
                }


            }

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
            contact.Statut = Contact.Statut;
            contact.Etat = Contact.Etat;
            contact.Adresse = Contact.Adresse;
            contact.Sexe = Contact.Sexe;
            contact.Nom = Contact.Nom;
            contact.Prenom = Contact.Prenom;
            contact.Profession = Contact.Profession;
            contact.ContactCanals = Contact.ContactCanals;
            contact.Pays = Contact.Pays;
            contact.Situation = Contact.Situation;
            contact.DateDeNaissance = Contact.DateDeNaissance;
            return Contact;

        }



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
        public List<ContactCanal> GetContactCanalCanals()
        {
            return _dbcontextGC.ContactCanals.ToList();
        }


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
