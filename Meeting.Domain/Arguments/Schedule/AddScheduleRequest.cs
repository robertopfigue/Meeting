using Meeting.Domain.Interfaces.Services;
using Meeting.Domain.ValueObjects;
using System;

namespace Meeting.Domain.Arguments.Schedule
{
    public class AddScheduleRequest : IRequest
    {
        public string Title { get; set; }

        public Guid Room { get; set; }

        public Guid User { get; set; }

        public Date Date { get; set; }
    }
}
