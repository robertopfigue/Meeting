using Meeting.Domain.Interfaces.Arguments;
using System;

namespace Meeting.Domain.Arguments.Room
{
    public class AddRoomResponse : IResponse
    {
        public int Number { get; set; }

        public string Message { get; set; }

        public static explicit operator AddRoomResponse(Entities.Room entidade)
        {
            return new AddRoomResponse()
            {
                Number = entidade.Number,
                Message = "Sala cadastrada com sucesso"
            };
        }
    }
}
