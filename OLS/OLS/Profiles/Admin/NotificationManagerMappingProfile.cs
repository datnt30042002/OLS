using AutoMapper;
using OLS.DTO.Notifications.Admin;
using OLS.Models;

namespace OLS.Profiles.Admin
{
    public class NotificationManagerMappingProfile : Profile
    {
        public NotificationManagerMappingProfile() 
        {
            CreateMap<Notification, NotificationReadAdminDTO>()
                .ReverseMap();

            CreateMap<Notification, NotificationCreateAdminDTO>()
                .ReverseMap();

            CreateMap<Notification, NotificationUpdateAdminDTO>()
                .ReverseMap();
        }
    }
}
