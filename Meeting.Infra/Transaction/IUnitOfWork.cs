namespace Meeting.Infra.Transaction
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
