using AutoMapper;
using Model.DbEntities;
using Model.Dtos;

namespace WebApi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BookingForAddDto, Booking>()
                .ForMember(d => d.Date, o => o.MapFrom(s => DateTime.UtcNow));

        }
    }
}
