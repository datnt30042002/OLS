using AutoMapper;
using OLS.DTO.Users.Admin;
using OLS.Models;
using OLS.HelperFunctions;

namespace OLS.Helpers.Admin
{
    public class UserManagerMappingProfile : Profile
    {
        public UserManagerMappingProfile()
        {
            // Read
            CreateMap<User, UserReadAdminDTO>()
                .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.UserRoleRole.RoleName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Dob.GetCurrentAge()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => HelperFunctions.HelperFunctions.GetStatusString(src.Status)))
                .ReverseMap(); // Reverse map có nghĩa là map ngược lại

            // Vấn đề ở đây
            CreateMap<UserCreateAdminDTO, User>()
                .ReverseMap();
        }
    }
}
