using Meeting.Domain.Arguments.Room;

namespace Meeting.Domain.Interfaces.Services
{
    public interface IServiceRoom
    {
        AddRoomResponse AddRoom(AddRoomRequest request);
    }
}
