using API_Models.Models;
using API_Models.Requests.Authentication_Requests;
using AutoMapper;

namespace API_Project.Helpers
{
    public class AMapperProfile : Profile
    {
        public AMapperProfile() 
        {
            CreateMap<User, AuthenticationResponse>();
            CreateMap<RegisterRequest, User>();
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition((src, dest, prop) =>
                {
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                    return true;
                }
                ));
        }
    }
}
