using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("medicalHistory")]
    public class MedicalHistory
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(80, ErrorMessage = "Name can't be longer than 80 characters")]
        public string NameDisease { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(Pet))]
        public Guid PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
