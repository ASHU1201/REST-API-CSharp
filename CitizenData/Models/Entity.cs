﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitizenData.Models
{
    public class Entity
    {
        public List<Address>? Addresses { get; set; }
        public List<Date> Dates { get; set; }
        public bool Deceased { get; set; }
        public string Id { get; set; }
        public List<Name> Names { get; set; }
        public string? Gender { get; set; }
    }
}
