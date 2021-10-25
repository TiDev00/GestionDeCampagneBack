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
            Random rnd = new Random();
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
                    int card = rnd.Next(10000, 99999);

                    Contact.Matricule = "MCT0000"+ card + (maxId + 1).ToString();
                    Contact.Etat = true;
                    Contact.Statut = true;

                    _dbcontextGC.Contacts.Add(Contact);
                }
                else
                {

                    int card = rnd.Next(10000, 99999);
                    Contact.Matricule = "MCT0000"+card+"1";
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
            contact.Prenom = Contact.Prenom;
            contact.Nom = Contact.Nom;
            contact.Pays = Contact.Pays;
            contact.Sexe = Contact.Sexe;
            contact.Profession = Contact.Profession;
            contact.Situation = Contact.Situation;
            contact.DateDeNaissance = Contact.DateDeNaissance;
            contact.Adresse = Contact.Adresse;
            contact.Etat = Contact.Etat;
            contact.Statut = Contact.Statut;
            contact.IdNiveauVisibilite = Contact.IdNiveauVisibilite;
            contact.IdUser = Contact.IdUser;
   
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

        public List<Contact> GetContacts(int idEntite)
        {
            return _dbcontextGC.Contacts.Where(r => r.Etat == true && r.IdEntite == idEntite).ToList();
        }

        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }


       
    }
}
