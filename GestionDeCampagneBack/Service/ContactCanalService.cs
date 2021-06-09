using GestionDeCampagneBack.Models;
using GestionDeCampagneBack.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.Service
{

    public class ContactCanalService : IContactCanal
    {
        private DbcontextGC _dbcontextGC;

        public ContactCanalService(DbcontextGC dbcontextGC)
        {
            _dbcontextGC = dbcontextGC;
        }
        public void AddContactCanal(ContactCanal ContactCanal)
        {
            if (ContactCanal == null)
            {
                throw new ArgumentNullException(nameof(ContactCanal));

            }

            _dbcontextGC.ContactCanals.Add(ContactCanal);
        }

        public void DeleteContactCanal(ContactCanal ContactCanal)
        {
            if (ContactCanal == null)
            {
                throw new ArgumentNullException(nameof(ContactCanal));

            }
            _dbcontextGC.ContactCanals.Remove(ContactCanal);
            // _dbcontextGC.ContactCanals.Remove(ContactCanal);

        }

        public ContactCanal EditContactCanal(ContactCanal ContactCanal, int id)
        {
            var contactCanal = _dbcontextGC.ContactCanals.Find(id);
            ContactCanal.Etat = true;
            return ContactCanal;
        }

        public ContactCanal GetContactCanalById(int id)
        {
            var value = _dbcontextGC.ContactCanals.Find(id);
            return value;
        }


        public List<ContactCanal> GetContactCanals()
        {
            return _dbcontextGC.ContactCanals.ToList();
        }
        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }

    
    }
}
