using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Core
{

    // Adding Automapper profile
    public class MappingProfiles: Profile 
    {

        public MappingProfiles()
        
        
        {

           CreateMap<Activity,Activity>();

        }
        
    }
}