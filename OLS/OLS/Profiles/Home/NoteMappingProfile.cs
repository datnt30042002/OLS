using AutoMapper;
using OLS.DTO.Notes.Home;
using OLS.Models;

namespace OLS.Profiles.Home
{
    public class NoteMappingProfile : Profile
    {
        public NoteMappingProfile() 
        {
            CreateMap<Note, NoteReadHomeDTO>()
                .ReverseMap();

            CreateMap<Note, NoteCreateHomeDTO>()
                .ReverseMap();

            CreateMap<Note, NoteUpdateHomeDTO>()
                .ReverseMap();
        }
    }
}
