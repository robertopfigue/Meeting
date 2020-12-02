using Meeting.Api.Controllers.Base;
using Meeting.Domain.Arguments.User;
using Meeting.Domain.Interfaces.Services;
using Meeting.Infra.Transaction;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Meeting.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _serviceUser;

        public UserController(IUnitOfWork unitOfWork ,IServiceUser serviceUser) : base(unitOfWork)
        {
            _serviceUser = serviceUser;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AddUserRequest request)
        {
            try
            {
                var response = _serviceUser.AddUser(request);

                return await ResponseAsync(response, _serviceUser);
            }
            catch(Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Auth")]
        [HttpPost]
        public async Task<HttpResponseMessage> Auth(AuthenticateUserRequest request)
        {
            try
            {
                var response = _serviceUser.AuthenticateUser(request);

                return await ResponseAsync(response, _serviceUser);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}