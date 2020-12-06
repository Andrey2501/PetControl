using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("notificationToUsers")]
    public class NotificationToUsers
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public Guid PetId { get; set; }
    }
}
