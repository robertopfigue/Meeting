using Meeting.Domain.Entities;
using Meeting.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meeting.Infra.Persistence.Repositories
{
    public class RepositoryUser : IRepositoryUser
    {
        protected readonly MeetingContext _context;

        public RepositoryUser(MeetingContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User AuthenticateUser(string email, string senha)
        {
            var user = _context.Users.Where(x => x.Email.Address == email && x.Senha == senha).FirstOrDefault();

            return user;

        }

        public List<User> ListUser()
        {
            var list = _context.Users.ToList();

            if(list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }
    }
}
