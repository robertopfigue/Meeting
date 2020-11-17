using Meeting.Domain.Enum;
using System;

namespace Meeting.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public EnumRoomStatus Status { get; set; }
    }
}
