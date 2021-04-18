using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class PrivateRenamedObjectLog
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public string OriginalName { get; set; }
    }
}
