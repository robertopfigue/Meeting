using Meeting.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting.Domain.Arguments.Room
{
    public class ListRoomReservedResponse : IResponse
    {
        public int NumberRoom { get; set; }

        public static explicit operator ListRoomReservedResponse(Entities.Room entidade)
        {
            return new ListRoomReservedResponse()
            {
                NumberRoom = entidade.Number
            };
        }
    }
}
