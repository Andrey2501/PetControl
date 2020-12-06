using Entities;
using Entities.Models;
using Entities.Parameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPetRepository : IRepositoryBase<Pet>
    {
        PagedList<StatisticModel> GetStatisticConutries(StatisticParameters parameters);
    }
}
