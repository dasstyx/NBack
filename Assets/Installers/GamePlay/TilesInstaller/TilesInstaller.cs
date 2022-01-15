using Pallada.Gameplay.TilesGrid.Entity;
using Pallada.Gameplay.TilesGrid.MakeGrid;
using Pallada.Gameplay.TilesGrid.Randomizer;
using Pallada.Gameplay.TilesGrid.Tiles;
using Pallada.Preset.SO;
using Pallada.Settings;
using UnityEngine;
using Zenject;

namespace Installers.GamePlay.TilesInstaller
{
    public class TilesInstaller : MonoBehaviour
    {
        public GameChancesSettings GameChances;
        public GridParamsSettings GridParams;

        public void InstallTiles(DiContainer subContainer)
        {
            var persistantData = subContainer.Resolve<PresetData>();

            subContainer.Bind<IGridParams>()
                .FromInstance(GridParams)
                .AsSingle()
                .OnInstantiated<GridParamsSettings>(
                    (_, obj) => obj.Setup(persistantData.tileCount)
                );

            subContainer.BindFactory<IGridEntity, GridEntityFactory>()
                .FromFactory<GridEntityPrefabFactory>();


            subContainer.Bind<GameChancesSettings>().FromInstance(GameChances).AsSingle();
            subContainer.Bind<Tiles>().AsSingle();

            subContainer.Bind<ITileRandomizer>().To<TileRandomizer>().AsSingle();
            subContainer.Bind<TilesHighlighter>().AsSingle();

            subContainer.Bind<TilesData>().FromFactory<MakeGridFactory>().AsSingle();
        }
    }
}