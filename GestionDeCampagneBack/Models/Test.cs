﻿using System;
using System.Collections.Generic;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Test
    {
        public int SchemaId { get; set; }
        public string TestClassName { get; set; }
        public int ObjectId { get; set; }
        public string Name { get; set; }
    }
}
