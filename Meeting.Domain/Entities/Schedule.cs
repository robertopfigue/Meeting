using Meeting.Domain.Entities;
using Meeting.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using System;

namespace Meeting.Domain.Entities
{
    public class Schedule : Notifiable
    {
        public Schedule()
        {
        }

        public Schedule(string title, Guid room, Guid user, Date date)
        {
            Id = Guid.NewGuid();
            Title = title;
            RoomId = room;
            UserId = user;
            Date = date;

            new AddNotifications<Schedule>(this)
                .IfLengthGreaterThan(x => x.Title, 50, "O título não pode conter mais de 50 caracteres.")
                .IfNull(x => x.Title, "O título deve ser preenchido.");

            AddNotifications(date);
        }

        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public Room Room { get; private set; }

        public User User { get; private set; }

        public Date Date { get; private set; }

        public Guid UserId { get; private set; }

        public Guid RoomId { get; private set; }
    }
}
