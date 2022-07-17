using CustomerSupport.Domain.Entities;
using CustomerSupport.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerSupport.Infra.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
