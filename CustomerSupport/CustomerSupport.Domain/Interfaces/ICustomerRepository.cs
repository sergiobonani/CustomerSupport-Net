using CustomerSupport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerSupport.Domain.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
    }
}
