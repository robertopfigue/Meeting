using Meeting.Infra.Persistence;

namespace Meeting.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeetingContext _context;

        public UnitOfWork(MeetingContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
