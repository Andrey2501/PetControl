using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class MedicalHistoryRepository : RepositoryBase<MedicalHistory>, IMedicalHistoryRepository
    {
        public MedicalHistoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
