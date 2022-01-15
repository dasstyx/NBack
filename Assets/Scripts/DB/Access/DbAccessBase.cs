namespace Pallada.DB
{
    public abstract class DbAccessBase : IDbAccess
    {
        protected IRepository repository;

        public DbAccessBase(IRepository repository)
        {
            this.repository = repository;
        }
    }
}