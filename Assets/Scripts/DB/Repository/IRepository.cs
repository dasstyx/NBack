using System.Data.Common;

namespace Pallada.DB
{
    public interface IRepository
    {
        DbConnection DbConnection();
    }
}