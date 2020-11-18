using Meeting.Domain.Interfaces.Arguments;
using System;

namespace Meeting.Domain.Arguments.User
{
    public class AddUserResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public static explicit operator AddUserResponse(Entities.User entidade)
        {
            return new AddUserResponse()
            {
                Id = entidade.Id,
                Message = "Operação realizada com sucesso"
            };
        }
    }
}
