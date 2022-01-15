using Pallada.DB;
using Pallada.Gameplay.GameState;
using Zenject;

namespace Installers.Menu
{
    public class SqlRepoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IRepository>().To<SqLiteRepository>().AsSingle();

            BindDbAccess();

            Container.Bind<PersistentData>().FromFactory<PersistentDataFactory>().AsSingle();
        }

        private void BindDbAccess()
        {
            Container.Bind<IHitsMedianFromDb>().To<HitsMedianFromDb>().AsSingle();
            Container.Bind<IMissesMedianFromDb>().To<MissesMedianFromDb>().AsSingle();
            Container.Bind<IWriteScoreToDb>().To<WriteScoreToDb>().AsSingle();
            Container.Bind<IWritePresetToDb>().To<WritePresetToDb>().AsSingle();
            Container.Bind<IWriteScorePresetTupleToDb>().To<WriteScorePresetTupleToDb>().AsSingle();

            Container.Bind<DBAggregator>().AsSingle();
        }
    }
}