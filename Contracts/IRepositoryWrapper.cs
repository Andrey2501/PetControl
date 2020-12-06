using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IPetRepository Pet { get; }
        IVaccinationRepository Vaccination { get; }
        IContactRepository Contact { get; }
        IMedicalHistoryRepository MedicalHistory { get; }
        INotificationRepository Notification { get; }
        INotificationToUsersRepository NotificationToUsers { get; }
        void Save();
    }
}
