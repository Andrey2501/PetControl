﻿using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private IUserRepository _user;
        private IPetRepository _pet;
        private IContactRepository _contact;
        private IVaccinationRepository _vaccination;
        private IMedicalHistoryRepository _medicalHistory;
        private INotificationRepository _notification;
        private INotificationToUsersRepository _notificationToUsers;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public IPetRepository Pet
        {
            get
            {
                if (_pet == null)
                {
                    _pet = new PetRepository(_repoContext);
                }
                return _pet;
            }
        }
        public IVaccinationRepository Vaccination
        {
            get
            {
                if (_vaccination == null)
                {
                    _vaccination = new VaccinationRepository(_repoContext);
                }
                return _vaccination;
            }
        }
        public IContactRepository Contact
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactRepository(_repoContext);
                }
                return _contact;
            }
        }
        public IMedicalHistoryRepository MedicalHistory
        {
            get
            {
                if (_medicalHistory == null)
                {
                    _medicalHistory = new MedicalHistoryRepository(_repoContext);
                }
                return _medicalHistory;
            }
        }
        public INotificationRepository Notification
        {
            get
            {
                if (_notification == null)
                {
                    _notification = new NotificationRepository(_repoContext);
                }
                return _notification;
            }
        }

        public INotificationToUsersRepository NotificationToUsers
        {
            get
            {
                if (_notificationToUsers == null)
                {
                    _notificationToUsers = new NotificationToUsersRepository(_repoContext);
                }
                return _notificationToUsers;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
