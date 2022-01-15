using Pallada.Gameplay.GameState;
using Pallada.Gameplay.GameState.GameResult;
using Pallada.Gameplay.GameState.GameStep;
using Pallada.Gameplay.InputStage;
using Pallada.Gameplay.MediansContainer;
using Pallada.Gameplay.Score;
using Pallada.Gameplay.TilesGrid.Randomizer;
using Pallada.Gameplay.Verifier;
using Pallada.Preset.SO;
using UI.Presets.LoadLevel;
using UnityEngine;
using Zenject;

namespace Installers.GamePlay
{
    public class GamePlayInstaller : MonoInstaller
    {
        [SerializeField] private TilesInstaller.TilesInstaller _tilesInstaller;
        [SerializeField] private PresetData defaultPreset;

        [SerializeField] private int timeScale = 5;

        private readonly RoundEndInstaller _roundEndInstaller = new();

        public override void InstallBindings()
        {
            PresetInstall();

            Container.Bind<InputStage>().AsSingle();
            Container.Bind<ChooseRightTile>().AsSingle();
            Container.Bind<Verifier>().AsSingle();
            Container.Bind<AutoVerifier>().AsSingle();
            InstallGrid();

            _tilesInstaller.InstallTiles(Container);

            Container.Bind<GameProcess>().AsSingle();
            Container.Bind<GameStep>().AsSingle();

            Container.Bind<GameResult>().AsSingle();
            Container.Bind<ReturnToMenu>().AsSingle();
            Container.Bind<LoadGame>().AsSingle();

            Container.Bind<MediansContainer>().AsSingle();

            _roundEndInstaller.InstallRoundEnd(Container);

            Time.timeScale = timeScale;
        }

        private void PresetInstall()
        {
            var isPersistentDataInstalled = Container.TryResolve<PersistentData>() != null;
            if (isPersistentDataInstalled)
            {
                Container.Bind<PresetData>().FromResolveGetter<PersistentData>(x => x.Preset).AsSingle();
            }
            else
            {
                Container.Bind<PresetData>().FromInstance(defaultPreset);
                Container.Bind<PersistentData>().FromFactory<PersistentDataFactory>().AsSingle();
            }
        }

        private void InstallGrid()
        {
            var nBack = Container.Resolve<PresetData>().nback;
            Container.Bind<int>().FromInstance(nBack).AsSingle().WhenInjectedInto<Verifier>();

            Container.Bind<GridClickHandler>().AsSingle();
            Container.Bind<MissesHandler>().AsSingle().NonLazy();

            Container.Bind<ITotalTilesCount>().To<TotalTilesCount>().AsSingle();
            Container.Bind<ITotalHitsCount>().To<TotalHitsCount>().AsSingle();
            Container.Bind<IHitsScore>().To<TileHitsScore>().AsSingle();
            Container.Bind<IMissesScore>().To<TileMissesScore>().AsSingle();
            Container.Bind<IMissClicksScore>().To<MissClicksScore>().AsSingle();
        }
    }
}