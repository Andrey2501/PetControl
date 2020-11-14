using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetControlBackend.Models.MedicalHistoryModel
{
    public class MedicalHistoryDto
    {

        [Required]
        [StringLength(80, ErrorMessage = "NameDisease can't be longer than 80 characters")]
        public string NameDisease { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public Guid PetId { get; set; }
    }
}
