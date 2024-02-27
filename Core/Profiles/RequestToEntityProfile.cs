using AutoMapper;
using Core.Entities;
using Core.Request;

namespace Core.Profiles
{
    public class RequestToEntityProfile : Profile
    {
        public RequestToEntityProfile()
        {
            CreateMap<PlaneRequest, PlaneEntity>();
            CreateMap<PassengerRequest, PassengerEntity>();
            CreateMap<ReservationRequest, ReservationEntity>();
        }
    }
}
