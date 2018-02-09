using AutoMapper;
using Store.Model.Model;
using StoreWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreWeb.Mapping
{
    
        public class ViewModelToDomainMappingProfile : Profile
        {
            //public override string ProfileName
            //{
            //    get { return "ViewModelToDomainMappings"; }
            //}

        public ViewModelToDomainMappingProfile() : this("ViewModelToDomainMappings")
        {
            
        }

        public ViewModelToDomainMappingProfile(string ProfileName) : base(ProfileName)
        {
            CreateMap<GadgetFormViewModel, Gadget>()
                     .ForMember(g => g.Name, map => map.MapFrom(vm => vm.GadgetTitle))
                    .ForMember(g => g.Description, map => map.MapFrom(vm => vm.GadgetDescription))
                    .ForMember(g => g.Price, map => map.MapFrom(vm => vm.GadgetPrice))
                    .ForMember(g => g.Image, map => map.MapFrom(vm => vm.File))
                    .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.GadgetCategory));
        }


            //protected override void Configure()
            //{
            //    Mapper.CreateMap<GadgetFormViewModel, Gadget>()
            //        .ForMember(g => g.Name, map => map.MapFrom(vm => vm.GadgetTitle))
            //        .ForMember(g => g.Description, map => map.MapFrom(vm => vm.GadgetDescription))
            //        .ForMember(g => g.Price, map => map.MapFrom(vm => vm.GadgetPrice))
            //        .ForMember(g => g.Image, map => map.MapFrom(vm => vm.File.FileName))
            //        .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.GadgetCategory));
            //}
        }
    
}