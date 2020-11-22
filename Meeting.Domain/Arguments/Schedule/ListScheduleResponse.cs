using Meeting.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meeting.Domain.Arguments.Schedule
{
    public class ListScheduleResponse : IResponse
    {
        public string Title { get; set; }

        public  int RoomNumber { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        public static explicit operator ListScheduleResponse(Entities.Schedule entidade)
        {
            return new ListScheduleResponse()
            {
                Title = entidade.Title,
                RoomNumber = entidade.Room.Number,
                InitialDate = entidade.Date.InitialDate,
                FinalDate = entidade.Date.FinalDate
            };
        }
    }
}
