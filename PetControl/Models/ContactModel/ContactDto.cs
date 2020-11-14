using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetControlBackend.Models.ContactModel
{
    public class ContactDto
    {
        [Required(ErrorMessage = "Latitude is required")]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid FirstPetId { get; set; }

        [Required]
        public Guid SecondPetId { get; set; }
    }
}
