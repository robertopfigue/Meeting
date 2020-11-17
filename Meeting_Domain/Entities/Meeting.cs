using Meeting.Domain.Entities;
using System;

namespace Meeting.Domain.Entities
{
    public class Meeting
    {
        public Guid Id { get; set; }

        public Room Room { get; set; }

        public User User { get; set; }

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }
    }
}
