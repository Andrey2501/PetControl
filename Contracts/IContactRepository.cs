using Entities;
using Entities.Models;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Contracts
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        PagedList<Contact> FindByCondition(ContactParameters parameters, Expression<Func<Contact, bool>> expression);
    }
}
