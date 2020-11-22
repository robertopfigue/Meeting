using Meeting.Api.Controllers.Base;
using Meeting.Domain.Arguments.Room;
using Meeting.Domain.Interfaces.Services;
using Meeting.Infra.Transaction;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Meeting.Api.Controllers
{
    [RoutePrefix("api/room")]
    public class RoomController : ControllerBase
    {
        private readonly IServiceRoom _serviceRoom;

        public RoomController(IUnitOfWork unitOfWork, IServiceRoom serviceRoom) : base(unitOfWork)
        {
            _serviceRoom = serviceRoom;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AddRoomRequest request)
        {
            try
            {
                var response = _serviceRoom.AddRoom(request);

                return await ResponseAsync(response, _serviceRoom);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("ListaSalasLivres")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _serviceRoom.ListEmpstyRooms();

                return await ResponseAsync(response, _serviceRoom);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("ListaSalasReservadas")]
        [HttpGet]
        public async Task<HttpResponseMessage> ListReserved()
        {
            try
            {
                var response = _serviceRoom.ListReservedRooms();

                return await ResponseAsync(response, _serviceRoom);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}