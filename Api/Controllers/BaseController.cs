using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
        public abstract class BaseController<T> : ControllerBase
        {
            /// <summary>
            /// The logger
            /// </summary>
            public readonly ILogger<T> Logger;

            /// <summary>
            /// Initializes a new instance of the <see cref="BaseController{T}" /> class.
            /// </summary>
            /// <param name="factory">The factory.</param>
            protected BaseController(ILoggerFactory factory)
            {
                Logger = factory.CreateLogger<T>();
            }
        }
    
}
