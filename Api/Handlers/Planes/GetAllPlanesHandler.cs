
using Api.Queries.Planes;
using Core.Entities;
using MediatR;

namespace api.handlers.planes
{
    public class getAllplaneshandler : IRequestHandler<GetAllPlanesQuery, IEnumerable<PlaneEntity>>
    {
        public Task<IEnumerable<PlaneEntity>> Handle(GetAllPlanesQuery request, CancellationToken cancellationtoken)
        {
            throw new NotImplementedException();
        }
    }
}
