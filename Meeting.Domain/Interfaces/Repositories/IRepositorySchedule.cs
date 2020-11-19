using Meeting.Domain.Entities;
using System.Collections.Generic;

namespace Meeting.Domain.Interfaces.Repositories
{
    public interface IRepositorySchedule
    {
        Schedule AddSchedule(Schedule schedule);

        List<Schedule> ListSchedules();
    }
}
