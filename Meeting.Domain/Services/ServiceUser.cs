using Meeting.Domain.Arguments.User;
using Meeting.Domain.Entities;
using Meeting.Domain.Interfaces.Repositories;
using Meeting.Domain.Interfaces.Services;
using Meeting.Domain.ValueObjects;
using Meeting_Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;

namespace Meeting.Domain.Services
{
    public class ServiceUser : Notifiable ,IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public AddUserResponse AddUser(AddUserRequest request)
        {
            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);

            User user = new User(name, email, request.Senha);

            AddNotifications(user);

            if (user.IsInvalid())
            {
                return null;
            }

            user = _repositoryUser.AddUser(user);

            return (AddUserResponse)user; 
        }

        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            if (request == null)
            {
                AddNotification("AuthenticateUser", Message.X0_E_OBRIGATORIO.ToFormat("AuthenticateUser"));
            }

            var email = new Email(request.Email); 
            var user = new User(email, request.Senha);

            if (user.IsInvalid())
            {
                return null;
            }

            user = _repositoryUser.AuthenticateUser(user.Email.Address, user.Senha);

            return (AuthenticateUserResponse)user;
        }

        public List<User> SelectUser()
        {
            return _repositoryUser.ListUser();
        }
    }
}
