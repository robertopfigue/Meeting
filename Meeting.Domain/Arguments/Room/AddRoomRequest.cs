using Meeting.Domain.Interfaces.Services;

namespace Meeting.Domain.Arguments.Room
{
    public class AddRoomRequest : IRequest
    {
        public int Number { get; set; }
    }
}
