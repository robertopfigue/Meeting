using Meeting.Api.Controllers.Base;
using Meeting.Domain.Arguments.Schedule;
using Meeting.Domain.Interfaces.Services;
using Meeting.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Meeting.Api.Controllers
{
        [RoutePrefix("api/schedule")]
        public class ScheduleController : ControllerBase
        {
            private readonly IServiceSchedule _serviceSchedule;

            public ScheduleController(IUnitOfWork unitOfWork, IServiceSchedule serviceSchedule) : base(unitOfWork)
            {
                _serviceSchedule = serviceSchedule;
            }

            [Route("Adicionar")]
            [HttpPost]
            public async Task<HttpResponseMessage> Adicionar(AddScheduleRequest request)
            {
                try
                {
                    var response = _serviceSchedule.AddSchedule(request);

                    return await ResponseAsync(response, _serviceSchedule);
                }
                catch (Exception ex)
                {
                    return await ResponseExceptionAsync(ex);
                }
            }
        }
}