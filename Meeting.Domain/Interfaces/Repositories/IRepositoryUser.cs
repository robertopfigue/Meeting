using Meeting.Domain.Arguments.User;
using Meeting.Domain.Entities;
using System;

namespace Meeting.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser
    {
        User AuthenticateUser(string email, string senha);

        User AddUser(User user);

        User SelectUser(Guid Id);
    }
}
