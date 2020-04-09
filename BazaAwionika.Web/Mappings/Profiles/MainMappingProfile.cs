using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Model;

namespace BazaAwionika.Web
{
    public class MainMappingProfile : Profile
    {


        public MainMappingProfile()
        {
     
                  
        }
        public override string ProfileName
        {
            get { return "MainMappingProfile"; }
        }

  
    }
}