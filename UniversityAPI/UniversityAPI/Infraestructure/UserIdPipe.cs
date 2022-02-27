//using MediatR;
//using Microsoft.AspNetCore.Http;
//using System.Threading;
//using System.Threading.Tasks;
//using UniversityAPI.Services;

//namespace UniversityAPI.Infraestructure
//{
//    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
//    {
//        private HttpContext httpContext;

//        public UserIdPipe(IHttpContextAccessor accessor)
//        {
//            httpContext = accessor.HttpContext;
//        }

//        public Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
//        {
//            // Uncomment this on production environment
//            //var claim = httpContext.User.Claims
//            //    .FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))
//            //    .Value;
            
//            if (request is BaseRequest br)
//            {
//                br.UserID = "I am a User";
//            }

//            return next();
//        }
//    }
//}
