using AutoMapper;
using CustomerSupport.Application.ViewModels;
using CustomerSupport.Domain.Entities;

namespace CustomerSupport.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
