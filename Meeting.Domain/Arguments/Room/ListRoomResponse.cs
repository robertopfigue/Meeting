using Meeting.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meeting.Domain.Arguments.Room
{
    public class ListRoomResponse : IResponse
    {
        public int NumberRoom { get; set; }

        public static explicit operator ListRoomResponse(Entities.Room entidade)
        {
            return new ListRoomResponse()
            {
                NumberRoom = entidade.Number
            };
        }
    }
}
