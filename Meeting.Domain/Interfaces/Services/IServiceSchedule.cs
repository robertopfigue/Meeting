using Meeting.Domain.Arguments.Schedule;
using Meeting.Domain.Arguments.User;
using Meeting.Domain.Entities;
using Meeting.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace Meeting.Domain.Interfaces.Services
{
    public interface IServiceSchedule : IServiceBase
    {
        AddScheduleResponse AddSchedule(AddScheduleRequest request);
    }
}
