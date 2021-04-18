using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class PrivateSysIndex
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public int IndexId { get; set; }
        public byte Type { get; set; }
        public string TypeDesc { get; set; }
        public bool? IsUnique { get; set; }
        public int? DataSpaceId { get; set; }
        public bool? IgnoreDupKey { get; set; }
        public bool? IsPrimaryKey { get; set; }
        public bool? IsUniqueConstraint { get; set; }
        public byte FillFactor { get; set; }
        public bool? IsPadded { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsHypothetical { get; set; }
        public bool? IsIgnoredInOptimization { get; set; }
        public bool? AllowRowLocks { get; set; }
        public bool? AllowPageLocks { get; set; }
        public bool? HasFilter { get; set; }
        public string FilterDefinition { get; set; }
        public int? CompressionDelay { get; set; }
        public bool? SuppressDupKeyMessages { get; set; }
        public bool? AutoCreated { get; set; }
        public bool? OptimizeForSequentialKey { get; set; }
    }
}
