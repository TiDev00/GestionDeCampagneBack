using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{
    public class ContactListeDiffusionService : IContactListeDiffusion
    {
        private DbcontextGC _dbcontextGC;

        public ContactListeDiffusionService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddContactListeDeDiffusion(ContactListeDiffusion ContactListeDiffusion)
        {
            if (ContactListeDiffusion == null)
            {
                throw new ArgumentNullException(nameof(ContactListeDiffusion));

            }
            else
            {

                var countval = _dbcontextGC.ContactListeDiffusions.Count();
                if (countval >= 1)
                {
                    var maxId = _dbcontextGC.ContactListeDiffusions.Max(p => p.Id);

                    ContactListeDiffusion.Code = "Cd0000" + (maxId + 1).ToString();
                    ContactListeDiffusion.Etat = true;
                    ContactListeDiffusion.DateDesa = null;
                    ContactListeDiffusion.Raison = " ";

                    _dbcontextGC.ContactListeDiffusions.Add(ContactListeDiffusion);
                }
                else
                {

                    ContactListeDiffusion.Code = "Cd0001";
                    ContactListeDiffusion.Etat = true;
                    ContactListeDiffusion.DateDesa = null;
                    ContactListeDiffusion.Raison = " ";

                    _dbcontextGC.ContactListeDiffusions.Add(ContactListeDiffusion);
                }


            }

    }

    public void DeleteContactListeDeDiffusion(ContactListeDiffusion ContactListeDiffusion)
        {
            if (ContactListeDiffusion == null)
            {
                throw new ArgumentNullException(nameof(ContactListeDiffusion));

            }
            _dbcontextGC.ContactListeDiffusions.Remove(ContactListeDiffusion);
        }

        public ContactListeDiffusion EditContactListeDeDiffusion(ContactListeDiffusion ContactListeDiffusion, int Id)
        {

            var contactListeDiffusion = _dbcontextGC.ContactListeDiffusions.Find(Id);
            contactListeDiffusion.Code = ContactListeDiffusion.Code;
            contactListeDiffusion.Raison = ContactListeDiffusion.Raison;
            contactListeDiffusion.DateDesa = ContactListeDiffusion.DateDesa;

            return ContactListeDiffusion;

        }

        public List<ContactListeDiffusion> GetContactListeDeDiffusions()
        {
            return _dbcontextGC.ContactListeDiffusions.ToList();
        }

        public ContactListeDiffusion GetContactListeDiffusionByID(int id)
        {
            var ContactListeDiffusion = _dbcontextGC.ContactListeDiffusions.Find(id);
            return ContactListeDiffusion;
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
