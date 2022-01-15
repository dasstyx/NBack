using System.Collections.Generic;
using Pallada.Gameplay.GameState.RoundEnd;
using ScreenMgr;
using Zenject;

namespace Installers.GamePlay
{
    public class RoundEndInstaller
    {
        public void InstallRoundEnd(DiContainer subContainer)
        {
            subContainer.Bind<ScreenManager>().FromComponentInHierarchy().AsSingle();

            var effects = new List<IRoundEndEffect>
            {
                BindAndResolve<EndScreenStopGameProcess>(subContainer),
                BindAndResolve<EndScreenDelay>(subContainer),
                BindAndResolve<EndScreenFadeView>(subContainer, true),
                BindAndResolve<EndScreenResultsScreen>(subContainer)
            };

            subContainer.Bind<List<IRoundEndEffect>>()
                .FromInstance(effects)
                .AsSingle();

            subContainer.Bind<RoundEnd>().AsSingle();
        }

        private IRoundEndEffect BindAndResolve<T>(DiContainer subContainer, bool fromHierarchy = false)
            where T : IRoundEndEffect
        {
            if (fromHierarchy == true)
            {
                subContainer.Bind<T>().FromComponentInHierarchy().AsSingle();
            }
            else
            {
                subContainer.Bind<T>().AsSingle();
            }

            return subContainer.Resolve<T>();
        }
    }
}