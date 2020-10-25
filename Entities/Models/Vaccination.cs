using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("vaccination")]
    public class Vaccination
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(80, ErrorMessage = "Name can't be longer than 80 characters")]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string СonfirmationDocument { get; set; }


        [ForeignKey(nameof(Pet))]
        public Guid PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
