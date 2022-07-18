using CustomerSupport.Application.Interfaces;
using CustomerSupport.Application.Services;
using CustomerSupport.Application.Tests.Services.DataHelper;
using CustomerSupport.Application.ViewModels;
using FluentAssertions;
using Moq;
using Xunit;

namespace CustomerSupport.Application.Tests.Services
{
    public class CustomerServiceTests
    {
        public Mock<ICustomerService> MockService()
        {
            var mock = new Mock<ICustomerService>();
            mock.Setup(x => x.Add(It.IsAny<CustomerViewModel>())).Returns(new ViewModels.Notifications.ResultWrap<CustomerViewModel> { IsSuccess = true });
            mock.Setup(x => x.Update(It.IsAny<CustomerViewModel>())).Returns(new ViewModels.Notifications.ResultWrap<CustomerViewModel> { IsSuccess = true });
            return mock;
        }

        [Fact]
        public void AddNewCustomerSucess()
        {
            var service = MockService().Object;

            var newEntity = CustomerData.GetCustomer;

            var result = service.Add(newEntity);

            result.IsSuccess.Should().BeTrue();
        }

        [Theory]
        [InlineData(true, "teste@mail.com", "test description", 123, "3423423", 1)]
        public void AddNewCustomerWithInvalidFields(bool agree, string email, string description, int number,
            string phone, int type)
        {
            var service = MockService().Object;

            var newEntity = new CustomerViewModel
            {
                AgreeTerms = agree,
                Email = email,
                IssueDescription = description,
                Number =  number,
                Phone = phone,
                TypeInquiry = type
            };

            var result = service.Add(newEntity);

            result.IsSuccess.Should().BeTrue();
        }


        [Fact]
        public void UpdateCustomerSucess()
        {
            var service = MockService().Object;

            var newEntity = CustomerData.GetCustomer;

            var result = service.Update(newEntity);

            result.IsSuccess.Should().BeTrue();
        }

    }
}
