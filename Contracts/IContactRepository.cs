using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Contracts
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        PagedList<Contact> FindByCondition(QueryStringParameters parameters, Expression<Func<Contact, bool>> expression);
    }
}
