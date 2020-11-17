using Meeting.Domain.Arguments.User;
using System;

namespace Meeting.Domain.Interfaces.Services
{
    public interface IServiceUser
    {
        AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request);

        AddUserResponse AddUser(AddUserRequest request);
    }
}
