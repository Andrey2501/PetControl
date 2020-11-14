using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetControlBackend.Models.VaccinationModel
{
    public class VaccinationDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string СonfirmationDocument { get; set; }

        [Required]
        public Guid PetId { get; set; }
    }
}
