using Meeting.Domain.Entities;
using Meeting.Domain.ValueObjects;
using System;

namespace Meeting.Domain.Entities
{
    public class Schedule
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Room Room { get; set; }

        public User User { get; set; }

        public Date Date { get; set; }
    }
}
