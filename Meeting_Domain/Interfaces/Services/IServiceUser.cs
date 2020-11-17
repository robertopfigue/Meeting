using Meeting.Domain.Arguments.User;
using System;

namespace Meeting.Domain.Interfaces.Services
{
    public interface IServiceUser
    {
        string AuthenticateUser(string email, string senha);

        Guid AddUser(AddUserRequest);
    }
}
