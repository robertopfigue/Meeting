using prmToolkit.NotificationPattern;
using System;

namespace Meeting.Domain.Interfaces.Services.Base
{
    public interface IServiceBase : INotifiable, IDisposable
    {
    }
}
