using UI.Game.Results;
using Zenject;

namespace Installers.GamePlay
{
    public class GameInterfaceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ResultsView>().AsSingle();
            Container.Bind<ResultLineFactory>().AsSingle();
        }
    }
}