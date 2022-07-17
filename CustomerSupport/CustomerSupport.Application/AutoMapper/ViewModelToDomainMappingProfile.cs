using AutoMapper;
using CustomerSupport.Application.ViewModels;
using CustomerSupport.Domain.Entities;

namespace CustomerSupport.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}
