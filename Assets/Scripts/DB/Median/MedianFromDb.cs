using System.Linq;
using Dapper;
using Pallada.Preset.SO;

namespace Pallada.DB
{
    public abstract class MedianFromDb : DbAccessBase, IDbGetMedian<int>
    {
        private const string presetKeyColumn = "presetKey";


        public MedianFromDb(IRepository repository) : base(repository)
        {
        }

        protected abstract string table { get; }
        protected abstract string parameter { get; }

        public int Read(PresetData preset)
        {
            int nBackMin = preset.nback - 1,
                nBackMax = preset.nback;

            int tileCountMin = preset.tileCount - 2,
                tileCountMax = preset.tileCount + 2;

            int timeLimitMin = preset.timeLimit - 30,
                timeLimitMax = preset.timeLimit + 30;

            using (var cnn = repository.DbConnection())
            {
                var result = cnn.Query<int?>(
                    @$"
                    SELECT AVG({parameter})
                    FROM (SELECT {parameter}
		                FROM (
                            SELECT * FROM {table}
                            INNER JOIN preset as p
                            ON {table}.{presetKeyColumn} = p.id
                            WHERE 
                                p.nBack BETWEEN {nBackMin} AND {nBackMax}
                                AND p.tileCount BETWEEN {tileCountMin} AND {tileCountMax}
                                AND p.timeLimit BETWEEN {timeLimitMin} AND {timeLimitMax}
                        )
		                ORDER BY {parameter}
		                LIMIT 2 - (SELECT COUNT({parameter}) FROM {table}) % 2
		                OFFSET (SELECT (COUNT({parameter}) - 1) / 2
				        FROM {table})
                    );"
                ).First();
                if (result.HasValue)
                {
                    return result.Value;
                }

                return 0;
            }
        }
    }
}