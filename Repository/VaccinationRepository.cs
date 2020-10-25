using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class VaccinationRepository : RepositoryBase<Vaccination>, IVaccinationRepository
    {
        public VaccinationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
