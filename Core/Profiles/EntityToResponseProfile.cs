using AutoMapper;
using Core.Entities;
using Core.Response;

namespace Core.Profiles
{
    public class EntityToResponseProfile : Profile
    {
        public EntityToResponseProfile()
        {
            CreateMap<PlaneEntity, PlaneResponse>();
            CreateMap<PassengerEntity, PassengerResponse>();
            CreateMap<ReservationEntity, ReservationResponse>()
                .ForMember(dest => dest.PassengerResponses, opt => opt.MapFrom(src => src.Passengers));
        }
    }
}
