using AutoMapper;
using Core.Entities;
using Core.Request;
using Core.Response;

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
