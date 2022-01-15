using Pallada.Gameplay.Timer;
using Pallada.Preset.SO;
using Zenject;

namespace Installers.GamePlay
{
    public class TimerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var timeLimit = Container.Resolve<PresetData>().timeLimit;
            Container.Bind<ITimer>().To<Timer>().AsSingle();
            Container.Bind<int>().FromInstance(timeLimit).WhenInjectedInto<Timer>();
        }
    }
}