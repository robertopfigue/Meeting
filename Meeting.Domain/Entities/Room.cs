using Meeting_Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;

namespace Meeting.Domain.Entities
{
    public class Room : Notifiable
    {
        public Room()
        {
        }

        public Room(int number)
        {
            Id = Guid.NewGuid();
            Number = number;

            new AddNotifications<Room>(this)
                .IfGreaterThan(x => x.Number, 100, Message.X0_INVALIDO.ToFormat("Número"));
        }

        public Guid Id { get; set; }

        public int Number { get; set; }

        public ICollection<Schedule> Schedule { get; private set; }
    }
}
