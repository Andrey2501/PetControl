using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("user")]
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(60, ErrorMessage = "FirstName can't be longer than 60 characters")]
        public string FirstName { get; set; }

        [StringLength(60, ErrorMessage = "LastName can't be longer than 60 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is incorrect")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters")]
        public string Country { get; set; }

        public string City { get; set; }

        [Phone(ErrorMessage = "Phone is incorrect")]
        public string Phone { get; set; }

        public string PhotoUrl { get; set; }

    }
}
