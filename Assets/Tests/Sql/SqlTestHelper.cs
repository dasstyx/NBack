using Dapper;
using Pallada.DB;
using Zenject;

public class SqlTestHelper
{
    private readonly DiContainer container;

    public SqlTestRepository Repo;

    public SqlTestHelper(DiContainer container)
    {
        this.container = container;

        SetupTestRepository();
        SetupBindings();
    }

    private void SetupBindings()
    {
        container.Bind<IRepository>().FromInstance(Repo).AsSingle();
        container.Bind<ScoreDbEntry>().AsSingle();

        container.Bind<HitsMedianFromDb>().AsSingle();
        container.Bind<MissesMedianFromDb>().AsSingle();
        container.Bind<WriteScoreToDb>().AsSingle();
        container.Bind<WritePresetToDb>().AsSingle();
    }

    private void SetupTestRepository()
    {
        var sqliteConn = new SqLiteRepository().DbConnection();
        Repo = new SqlTestRepository(sqliteConn);
    }

    public void TearDown()
    {
        using (var cnn = Repo.DbConnection())
        {
            cnn.Query(
                @"DELETE FROM results;
                DELETE FROM preset;
                DELETE FROM sqlite_sequence;"
            );
        }
    }

    public WriteScoreToDb GetResultsWriter()
    {
        return WriteDb<WriteScoreToDb>();
    }

    public WritePresetToDb GetPresetsWriter()
    {
        return WriteDb<WritePresetToDb>();
    }

    public T1 ReadDb<T1, T2>()
        where T1 : IDbGetMedian<T2>
    {
        return container.Resolve<T1>();
    }

    public T WriteDb<T>()
    {
        return container.Resolve<T>();
    }

    public IDbAccess MakeDbAccess<T>()
        where T : IDbAccess
    {
        return container.Resolve<T>();
    }
}