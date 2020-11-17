using Meeting.Domain.Interfaces.Services;

namespace Meeting_Domain.Arguments.Room
{
    public class AddRoomRequest : IRequest
    {
        public int Number { get; set; }
    }
}
