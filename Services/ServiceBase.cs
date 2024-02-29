using AutoMapper;
using Core.Interfaces.Repository;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class ServiceBase<T>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public readonly ILogger<T> _logger;

        public ServiceBase(IUnitOfWork unitOfWork, IMapper mapper, ILoggerFactory factory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = factory.CreateLogger<T>();
        }
    }
}
