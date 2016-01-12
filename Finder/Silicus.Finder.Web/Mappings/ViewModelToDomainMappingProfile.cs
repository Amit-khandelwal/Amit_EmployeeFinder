using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Silicus.Finder.Models;
using Silicus.Finder.Web.Models;
using Silicus.Finder.Models.DataObjects;

namespace Silicus.Finder.Web.Mappings
{
    [ExcludeFromCodeCoverage]
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Model, EntityA>();
            Mapper.CreateMap<UserViewModel, User>();
            Mapper.CreateMap<User,UserViewModel>();
        }
    }
}