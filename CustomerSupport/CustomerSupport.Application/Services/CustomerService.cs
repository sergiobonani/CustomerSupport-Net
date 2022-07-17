using AutoMapper;
using CustomerSupport.Application.Interfaces;
using CustomerSupport.Application.Validations;
using CustomerSupport.Application.ViewModels;
using CustomerSupport.Application.ViewModels.Notifications;
using CustomerSupport.Domain.Entities;
using CustomerSupport.Domain.Interfaces;
using CustomerSupport.Resource;
using System;
using System.Collections.Generic;

namespace CustomerSupport.Application.Services
{
    public class CustomerService : IDisposable, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public ResultWrap<CustomerViewModel> Add(CustomerViewModel obj)
        {
            var result = new ResultWrap<CustomerViewModel>();

            if (obj == null)
            {
                return result.SetError(Geral.InvalidFields, EKnowErrors.BusinessError);
            }

            var entity = _mapper.Map<CustomerViewModel, Customer>(obj);

            var validation = new CustomerValidation().Validate(entity);

            if (!validation.IsValid)
            {
                return result.SetError(validation.Errors, EKnowErrors.BusinessError);
            }

            _customerRepository.Add(entity);

            return result.SetSuccess(obj);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            var list = _customerRepository.GetAll();

            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(list);
        }

        public CustomerViewModel GetById(Guid id)
        {
            var entity = _customerRepository.GetById(id);
            return _mapper.Map<Customer, CustomerViewModel>(entity);
        }

        public ResultWrap<CustomerViewModel> Remove(Guid id)
        {
            var result = new ResultWrap<CustomerViewModel>();

            var entity = _customerRepository.GetById(id);

            if (entity == null)
            {
                return result.SetError(string.Format(Geral.NotFound, Geral.Customer), EKnowErrors.NotFoundError);
            }

            _customerRepository.Remove(entity);

            return result.SetSuccess();
        }

        public ResultWrap<CustomerViewModel> Update(CustomerViewModel obj)
        {
            var result = new ResultWrap<CustomerViewModel>();

            var current = _customerRepository.GetById(obj.Id.Value);

            if (current == null)
            {
                return result.SetError(string.Format(Geral.NotFound, Geral.Customer), EKnowErrors.NotFoundError);
            }

            _mapper.Map<CustomerViewModel, Customer>(obj, current);

            var validation = new CustomerValidation().Validate(current);

            if (!validation.IsValid)
            {
                return result.SetError(validation.Errors, EKnowErrors.BusinessError);
            }

            _customerRepository.Update(current);

            return result.SetSuccess(obj);
        }
    }
}
