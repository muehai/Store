using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Store.Model.Model;
using StoreWeb.ViewModels;

namespace StoreWeb.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile(): this("DomainToViewModelMappings")
        { }

        public DomainToViewModelMappingProfile(string ProfileName) : base(ProfileName)
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Gadget, GadgetsViewModel>();
        }
    }
}
