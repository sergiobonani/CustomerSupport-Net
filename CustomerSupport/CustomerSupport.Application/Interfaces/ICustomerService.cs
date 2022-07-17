using CustomerSupport.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSupport.Application.Interfaces
{
    public interface ICustomerService : IServiceBase<CustomerViewModel>
    {
    }
}
