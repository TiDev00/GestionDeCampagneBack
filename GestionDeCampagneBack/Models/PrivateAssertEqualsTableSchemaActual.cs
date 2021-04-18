using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class PrivateAssertEqualsTableSchemaActual
    {
        public string Name { get; set; }
        public int? RankColumnId { get; set; }
        public string SystemTypeId { get; set; }
        public string UserTypeId { get; set; }
        public short? MaxLength { get; set; }
        public byte? Precision { get; set; }
        public byte? Scale { get; set; }
        public string CollationName { get; set; }
        public bool? IsNullable { get; set; }
        public bool? IsIdentity { get; set; }
    }
}
