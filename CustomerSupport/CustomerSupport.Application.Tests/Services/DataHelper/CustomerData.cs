using CustomerSupport.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSupport.Application.Tests.Services.DataHelper
{
    internal static class CustomerData
    {
        internal static Guid _id1 = Guid.NewGuid();
        internal static CustomerViewModel GetCustomer =>
            new CustomerViewModel
            {
                AgreeTerms = false,
                Email = "tst@mail.com",
                IssueDescription = "description",
                Id = _id1,
                Number = 123,
                Phone = "231",
                TypeInquiry = 1
            };

        internal static List<CustomerViewModel> GetList =>
            new List<CustomerViewModel>
            {
                GetCustomer
            };
    }
}
