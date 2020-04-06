using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            (CreateMap<UserViewModel, UserModel>()
                .ForMember(a => a.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(a => a.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(a => a.Password, map => map.MapFrom(vm => vm.Password))
                .ForMember(a => a.FirstName, map => map.MapFrom(vm => vm.LastName))
                .ForMember(a => a.LastName, map => map.MapFrom(vm => vm.LastName))
                .ForMember(a => a.AdminPriviliges, map => map.MapFrom(vm => vm.AdminPriviliges))).ReverseMap();


        }

        public override string ProfileName
        {
            get { return "UserMappingProfile"; }
        }
    }
}
