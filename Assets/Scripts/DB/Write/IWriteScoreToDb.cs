namespace Pallada.DB
{
    public interface IWriteScoreToDb : IDbWrite<ScoreDbEntry>
    {
        void Write(ScoreDbEntry data);
    }
}