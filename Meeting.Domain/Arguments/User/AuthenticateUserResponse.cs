using Meeting.Domain.Interfaces.Arguments;
using System;

namespace Meeting.Domain.Arguments.User
{
    public class AuthenticateUserResponse : IResponse
    {
        public string FirstName { get; set; }

        public string Email { get; set; }

        public static explicit operator AuthenticateUserResponse(Entities.User user)
        {
            return new AuthenticateUserResponse()
            {
                Email = user.Email.Address,
                FirstName = user.Name.FirstName
            };
        }
    }
}
