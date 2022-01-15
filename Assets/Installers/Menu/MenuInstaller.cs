using System.Collections.Generic;
using Pallada.Preset.ChoosePreset;
using Pallada.Preset.MakePreset;
using Pallada.Preset.SO;
using UI.Presets.LoadLevel;
using Zenject;

namespace Installers.Menu
{
    public class MenuInstaller : MonoInstaller
    {
        public List<PresetData> gamePersistantData;

        public override void InstallBindings()
        {
            Container.Bind<LoadGame>().AsSingle();

            Container.Bind<Dictionary<string, PresetData>>()
                .FromMethod(GetPersistantDict).AsSingle();

            Container.Bind<IChoosePreset>().To<ChoosePreset>().AsSingle();
            Container.Bind(typeof(IBuildPresetHolder), typeof(IChoosePresetHolder))
                .To(typeof(BuildPresetHolder), typeof(ChoosePresetHolder)).AsSingle();
            Container.Bind<IMakePreset>().To<MakePreset>().AsSingle();
        }

        private Dictionary<string, PresetData> GetPersistantDict()
        {
            var result = new Dictionary<string, PresetData>();
            foreach (var data in gamePersistantData)
            {
                result.Add(data.name, data);
            }

            return result;
        }
    }
}