using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class PrivateSysType
    {
        public string Name { get; set; }
        public byte SystemTypeId { get; set; }
        public int UserTypeId { get; set; }
        public int SchemaId { get; set; }
        public int? PrincipalId { get; set; }
        public short MaxLength { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }
        public string CollationName { get; set; }
        public bool? IsNullable { get; set; }
        public bool IsUserDefined { get; set; }
        public bool IsAssemblyType { get; set; }
        public int DefaultObjectId { get; set; }
        public int RuleObjectId { get; set; }
        public bool IsTableType { get; set; }
    }
}
