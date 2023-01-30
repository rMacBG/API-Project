using API_Models.Models;
using API_Models.Models.VModels.Authorization;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Models.Mappers
{
    public class UserMapper : Profile
    {

        public UserMapper()
        {
            CreateMap<User, RegisterVModel>();
        }
    }
}
