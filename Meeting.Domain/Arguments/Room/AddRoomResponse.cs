using Meeting.Domain.Interfaces.Arguments;

namespace Meeting.Domain.Arguments.Room
{
    public class AddRoomResponse : IResponse
    {
        public int Number { get; set; }

        public string Message { get; set; }
    }
}
