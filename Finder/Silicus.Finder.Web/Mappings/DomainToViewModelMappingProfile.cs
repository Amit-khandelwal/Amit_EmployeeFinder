//using Eda.RDBI.Web.ViewModel;

using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Silicus.Finder.Models;
using Silicus.Finder.Models.DataObjects;
using Silicus.Finder.Web.ViewModel;

namespace Silicus.Finder.Web.Mappings
{
    [ExcludeFromCodeCoverage]
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EntityA, Model>();
            Mapper.CreateMap<Employee, EmployeeViewModel>();
            Mapper.CreateMap<Contact, ContactViewModel>();
            Mapper.CreateMap<CubicalLocation, CubicalLocationViewModel>();
            // Example for member to member mapping
            //Mapper.CreateMap<OrganizationUser, OrganizationUserDataAccessViewModel>()
            //    .ForMember(o => o.Name, b => b.MapFrom(z => z.FirstName + " " + z.LastName));
            //Mapper.CreateMap<Order, OrderViewModel>()
            //    .ForMember(o => o.OrderDescription, b => b.MapFrom(z => z.Description))
            //                .ForMember(o => o.OrderId, b => b.MapFrom(z =>
            //                z.Id));
        }
    }
}