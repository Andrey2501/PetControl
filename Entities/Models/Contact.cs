﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("contact")]
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public Guid FirstPetId { get; set; }
        public Pet FirstPet { get; set; }
        public Guid SecondPetId { get; set; }
        public Pet SecondPet { get; set; }
    }
}
