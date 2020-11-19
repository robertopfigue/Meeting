using Meeting.Domain.Interfaces.Arguments;
using System;

namespace Meeting.Domain.Arguments.Schedule
{
    public class AddScheduleResponse : IResponse
    {
        public string Title { get; set; }

        public int RoomNumber { get; set; }

        public string Message { get; set; }

        public static explicit operator AddScheduleResponse(Entities.Schedule entidade)
        {
            return new AddScheduleResponse()
            {
                Title = entidade.Title,
                Message = "Reunão agenda com sucesso",
                RoomNumber = entidade.Room.Number
            };
        }
    }
}
