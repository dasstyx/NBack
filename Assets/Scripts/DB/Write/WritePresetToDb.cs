using System.Linq;
using Dapper;

namespace Pallada.DB
{
    public class WritePresetToDb : DbAccessBase, IWritePresetToDb
    {
        public WritePresetToDb(IRepository repository) : base(repository)
        {
        }

        public int Write(PresetDbEntry preset)
        {
            using (var cnn = repository.DbConnection())
            {
                cnn.Open();
                return cnn.Query<int>(
                    @"INSERT INTO preset
                ( nBack, tileCount, timeLimit, turnTime ) 
                VALUES ( 
                    @nBack, @tileCount, @timeLimit, @turnTime
                );
                SELECT id FROM preset WHERE 
                    nBack = @nBack
                    AND tileCount = @tileCount
                    AND timeLimit = @timeLimit
                    AND turnTime = @turnTime;",
                    preset).First();
            }
        }
    }
}