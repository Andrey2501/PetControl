using Contracts;
using Entities;
using Entities.Models;
using Entities.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Contact> FindByCondition(ContactParameters parameters, Expression<Func<Contact, bool>> expression)
        {
            IQueryable<Contact> contacts = FindByCondition(expression);

            SearchByDate(ref contacts, parameters.FromDate, parameters.ToDate);

            return PagedList<Contact>.ToPagedList(FindByCondition(expression),
                parameters.PageNumber,
                parameters.PageSize);
        }

        private void SearchByDate(ref IQueryable<Contact> contacts, DateTime fromDate, DateTime toDate)
        {
            if (!contacts.Any())
            {
                return;
            }

            contacts = contacts.Where(p => toDate >= p.Date && p.Date <= fromDate);
        }
    }
}
