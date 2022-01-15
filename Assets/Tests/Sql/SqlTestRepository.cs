using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using Pallada.DB;
using UnityEngine;

public class SqlTestRepository : IRepository, IDisposable
{
    private readonly DbConnection keepAliveConn;

    public SqlTestRepository(DbConnection originDb)
    {
        keepAliveConn = DbConnection();
        ReplicateDb(originDb);
    }

    public void Dispose()
    {
        keepAliveConn.Dispose();
    }

    public DbConnection DbConnection()
    {
        return new SQLiteConnection("DataSource=file:PalladaTestDb?mode=memory&cache=shared");
    }

    private void ReplicateDb(DbConnection originDb)
    {
        Func<string, string> getTableCreationSql =
            table => $"SELECT sql FROM sqlite_master WHERE type='table' AND name='{table}';";

        using (var testCnn = DbConnection())
        {
            var tableExistQuery =
                testCnn.Query<string>(getTableCreationSql("results"));
            if (tableExistQuery.Any())
            {
                Debug.LogWarning("The table already exists!");
                return;
            }

            var createTablesSql = new List<string>(2);
            using (var originCnn = originDb)
            {
                foreach (var table in new[] {"results", "preset"})
                {
                    var sql = originCnn.Query<string>(
                        getTableCreationSql(table)
                    ).First();
                    createTablesSql.Add(sql);
                }
            }

            testCnn.Query($"{createTablesSql[0]}; {createTablesSql[1]}");
        }
    }
}