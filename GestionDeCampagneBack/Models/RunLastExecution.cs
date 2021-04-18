using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class RunLastExecution
    {
        public string TestName { get; set; }
        public int? SessionId { get; set; }
        public DateTime? LoginTime { get; set; }
    }
}
