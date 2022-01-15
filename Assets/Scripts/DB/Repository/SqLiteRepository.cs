using System.Data.Common;
using System.Data.SQLite;

namespace Pallada.DB
{
    public class SqLiteRepository : RepositoryBase
    {
        protected override string dbFileName => "player_data.db";

        public override DbConnection DbConnection()
        {
            return new SQLiteConnection("Data Source=" + GetDatabasePath());
        }
    }
}