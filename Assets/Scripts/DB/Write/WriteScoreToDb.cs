using Dapper;

namespace Pallada.DB
{
    public class WriteScoreToDb : DbAccessBase, IWriteScoreToDb
    {
        public WriteScoreToDb(IRepository repository) : base(repository)
        {
        }

        public void Write(ScoreDbEntry data)
        {
            using (var cnn = repository.DbConnection())
            {
                cnn.Open();
                cnn.Query(
                    @"INSERT INTO results
                ( hits, misses, missClicks, 
                 totalHits, totalTiles, 
                 timeStamp, 
                 presetKey ) 
                VALUES ( 
                    @hits, @misses, @missClicks, 
                    @totalHits, @totalTiles,
                    strftime('%s', 'now'),
                    @presetKey
                );",
                    data);
            }
        }
    }
}