using Meeting.Domain.Arguments.Schedule;
using Meeting.Domain.Entities;
using Meeting.Domain.Services;
using Meeting.Domain.Interfaces.Services;
using Meeting.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using Meeting.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace Meeting.Domain.Services
{
    public class ServiceSchedule : Notifiable, IServiceSchedule
    {
        private readonly IRepositorySchedule _repositorySchedule;

        public ServiceSchedule(IRepositorySchedule repositorySchedule)
        {
            _repositorySchedule = repositorySchedule;
        }

        public AddScheduleResponse AddSchedule(AddScheduleRequest request)
        {
            ServiceUser createdUser = null;
            ServiceRoom roomSelect = null;
            var date = new Date(request.Date.InitialDate, request.Date.FinalDate);
            var user = createdUser.SelectUser(request.User);
            var room = roomSelect.SelectRoom(request.Room);

            var schedule = new Schedule(request.Title, room, user, request.Date);

            AddNotifications(schedule);

            if (schedule.IsInvalid())
            {
                return null;
            }

            if (ScheduleIsValid(schedule.Date.InitialDate, schedule.Date.FinalDate, schedule.Room.Id))
            {
                schedule = _repositorySchedule.AddSchedule(schedule);
            }
            else
            {
                AddNotification("Agendamento", "Está sala já está agendada neste horário");

                AddNotifications(schedule);

                return null;
            }

            return (AddScheduleResponse)schedule;
        }

        public bool ScheduleIsValid(DateTime initalDate, DateTime finalDate, Guid room)
        {
            var list = _repositorySchedule.ListSchedules();

            if (!list.Any())
            {
                return true;
            }

            foreach (var schedule in list)
            {
                if ((initalDate >= schedule.Date.InitialDate || finalDate <= schedule.Date.FinalDate) && room == schedule.Room.Id)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
