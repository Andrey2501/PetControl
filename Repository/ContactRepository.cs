using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Contact> FindByCondition(QueryStringParameters parameters, Expression<Func<Contact, bool>> expression)
        {
            return PagedList<Contact>.ToPagedList(FindByCondition(expression),
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}
