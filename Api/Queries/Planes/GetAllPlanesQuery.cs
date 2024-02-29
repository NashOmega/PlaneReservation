using Core.Entities;
using MediatR;

namespace Api.Queries.Planes
{
    public class GetAllPlanesQuery : IRequest<IEnumerable<PlaneEntity>>
    {
    }
}
