using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetControlBackend.Models.ContactModel
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public Guid FirstPetId { get; set; }
        public Guid SecondPetId { get; set; }
    }
}
