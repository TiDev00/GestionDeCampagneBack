using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class InfosMessage
    {

        public InfosMessage()
        {
      
            InfosMessageCampagnes = new HashSet<InfosMessageCampagne>();

        }


        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nombre de messages prévus est obligatoire")]
        public int MessagePrevu { get; set; }
        public int? MessageAchemines { get; set; }
        public int? MessageEnCours { get; set; }
        public int? MessageErreur { get; set; }

        public int IdCampagne { get; set; }

        [ForeignKey("IdCampagne")]
        public virtual Campagne Campagnes { get; set; }

        public virtual ICollection<InfosMessageCampagne> InfosMessageCampagnes { get; set; }
    }
}
