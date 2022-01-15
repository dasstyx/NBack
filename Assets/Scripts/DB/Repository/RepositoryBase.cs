using System.Data.Common;
using System.IO;
using UnityEngine;

namespace Pallada.DB
{
    public abstract class RepositoryBase : IRepository
    {
        protected abstract string dbFileName { get; }


        public abstract DbConnection DbConnection();

        /// <summary> Возвращает путь к БД. Если её нет в нужной папке на Андроиде, то копирует её с исходного apk файла. </summary>
        protected string GetDatabasePath()
        {
#if UNITY_STANDALONE
            var filePath = Path.Combine(Application.dataPath, dbFileName);
            if (!File.Exists(filePath))
            {
                UnpackDatabase(filePath);
            }

            return filePath;
#elif UNITY_ANDROID
            string filePath = Path.Combine(Application.persistentDataPath, fileName);
            if(!File.Exists(filePath)) UnpackDatabase(filePath);
            return filePath;
#endif
        }

        /// <summary> Распаковывает базу данных в указанный путь. </summary>
        /// <param name="toPath"> Путь в который нужно распаковать базу данных. </param>
        protected void UnpackDatabase(string toPath)
        {
            var fromPath = Path.Combine(Application.streamingAssetsPath, dbFileName);

            var reader = new WWW(fromPath);
            while (!reader.isDone)
            {
            }

            File.WriteAllBytes(toPath, reader.bytes);
        }
    }
}