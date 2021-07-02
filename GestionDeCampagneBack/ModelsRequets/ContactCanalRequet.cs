using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDeCampagneBack.ModelsRequets
{
    public class ContactCanalRequet
    {
        [Required(ErrorMessage = "Le nom complet est obligatoire")]
        [StringLength(100, MinimumLength = 2,
       ErrorMessage = "Le Nom doit comporter au minimum 2 caractères et au maximum 100 caractères")]
        [DataType(DataType.Text)]
        public virtual string NomComplet { get; set; }

        [Required(ErrorMessage = "Le sexe est obligatoire")]
        [StringLength(100, ErrorMessage = "Le Sexe doit comporter au minimum 5 caractères et au maximum 100 caractères", MinimumLength = 5)]
        [DataType(DataType.Text)]
        public virtual string Sexe { get; set; }

  
        public virtual int NiveauDeVisibilite { get; set; }

        public virtual int idContact { get; set; }


        public virtual int Telephone { get; set; }

        public virtual bool Statut { get; set; }


        public virtual int Mail { get; set; }



        public virtual int Whatsapp { get; set; }

 
        public virtual int Facebook { get; set; }

    }
}
