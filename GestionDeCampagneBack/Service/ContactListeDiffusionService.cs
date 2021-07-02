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
        public void AddContactListeDiffusion(ContactListeDiffusion ContactListeDiffusion)
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

                    ContactListeDiffusion.Code = "C0000" + (maxId + 1).ToString();
                    ContactListeDiffusion.Etat = true;

                    _dbcontextGC.ContactListeDiffusions.Add(ContactListeDiffusion);
                }
                else
                {
                    ContactListeDiffusion.Code = "C00001";
                    ContactListeDiffusion.Etat = true;
                    _dbcontextGC.ContactListeDiffusions.Add(ContactListeDiffusion);
                }
            }
        }

        public void DeleteContactListeDiffusion(ContactListeDiffusion ContactListeDiffusion)
        {
            if (ContactListeDiffusion == null)
            {
                throw new ArgumentNullException(nameof(ContactListeDiffusion));

            }
            _dbcontextGC.ContactListeDiffusions.Remove(ContactListeDiffusion);
            // _dbcontextGC.ContactListeDiffusions.Remove(ContactListeDiffusion);

        }

        public ContactListeDiffusion EditContactListeDiffusion(ContactListeDiffusion ContactListeDiffusion, int id)
        {
            var contactListeDiffusion = _dbcontextGC.ContactListeDiffusions.Find(id);
            ContactListeDiffusion.Etat = true;
            return ContactListeDiffusion;
        }

        public ContactListeDiffusion GetContactListeDiffusionById(int id)
        {
            var value = _dbcontextGC.ContactListeDiffusions.Find(id);
            return value;
        }

        public ContactListeDiffusion GetContactListeDiffusionByCode(string Code)
        {
            var user = _dbcontextGC.ContactListeDiffusions.FirstOrDefault(r => r.Code == Code);
            if (user != null)
                return user;
            else return null;
        }

        public List<ContactListeDiffusion> GetContactListeDiffusions(int id)
        {
            return _dbcontextGC.ContactListeDiffusions.ToList();
        }
        public bool SaveChanges()
        {
            return (_dbcontextGC.SaveChanges() >= 0);
        }
    }
}
