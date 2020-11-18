using Meeting.Domain.Arguments.User;
using Meeting.Domain.Interfaces.Services.Base;
using System;

namespace Meeting.Domain.Interfaces.Services
{
    public interface IServiceUser : IServiceBase
    {
        AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request);

        AddUserResponse AddUser(AddUserRequest request);
    }
}
