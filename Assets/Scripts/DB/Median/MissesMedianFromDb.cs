namespace Pallada.DB
{
    public class MissesMedianFromDb : MedianFromDb, IMissesMedianFromDb
    {
        public MissesMedianFromDb(IRepository repository) : base(repository)
        {
        }

        protected override string table => "results";
        protected override string parameter => "misses";
    }
}