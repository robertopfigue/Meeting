using Meeting.Domain.Interfaces.Arguments;

namespace Meeting.Domain.Arguments.User
{
    public class AuthenticateUserResponse : IResponse
    {
        public string FirstName { get; set; }

        public string Email { get; set; }
    }
}
