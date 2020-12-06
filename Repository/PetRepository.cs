using Contracts;
using Entities;
using Entities.Models;
using Entities.Parameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        private RepositoryContext context;
        public PetRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            context = repositoryContext;
        }

        public PagedList<StatisticModel> GetStatisticConutries(StatisticParameters parameters)
        {
            /*var statistics2 = context.Users.Where(u => u.Country != null)
               .Join(
                   context.Pets.Where(p => p.IsSick),
                   u => u.Id,
                   p => p.UserId,
                   (u, p) => new
                   {
                       p.Id,
                       u.Country
                   }
               )
               .Join(
                   context.MedicalHistories.Where(m => m.EndDate == null),
                   up => up.Id,
                   m => m.PetId,
                   (up, m) => new
                   {
                       up.Id,
                       up.Country,
                       m.NameDisease,
                   }
               )
               .GroupBy(upm => upm.Id)
               .Select(upm => new {
                   Id = upm.Key,
                   Country = upm.Select(u => u.Country).FirstOrDefault(),
               });*/
            IQueryable<StatisticModel> statistics = context.Users
                .Join(
                    context.Pets.Where(p => p.IsSick),
                    u => u.Id,
                    p => p.UserId,
                    (u, p) => new
                    {
                        p.Id,
                        u.Country
                    }
                )
                .Join(
                    context.MedicalHistories.Where(m => m.EndDate == null),
                    up => up.Id,
                    m => m.PetId,
                    (up, m) => new
                    {
                        m.PetId,
                        up.Country,
                        m.NameDisease,
                    }
                )
                .GroupBy(upm => upm.Country)
                .Select(upm => new StatisticModel()
                {
                    Country = upm.Key,
                    Count = upm.Count()
                });

            return PagedList<StatisticModel>.ToPagedList(statistics,
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}
