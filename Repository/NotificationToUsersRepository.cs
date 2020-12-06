using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class NotificationToUsersRepository : RepositoryBase<NotificationToUsers>, INotificationToUsersRepository
    {
        public NotificationToUsersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
