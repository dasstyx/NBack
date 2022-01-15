using UnityEngine.SceneManagement;
using Zenject;

namespace UI.Presets.LoadLevel
{
    public abstract class LoadLevelBase
    {
        [Inject] protected ZenjectSceneLoader _sceneLoader;

        protected abstract string levelName { get; }


        protected virtual void Load<T>(T data)
        {
            _sceneLoader.LoadScene(levelName, LoadSceneMode.Single, container => { container.BindInstance(data); });
        }

        protected virtual void Load<T1, T2>(T1 data1, T2 data2)
        {
            _sceneLoader.LoadScene(levelName, LoadSceneMode.Single, container =>
            {
                container.BindInstance(data1);
                container.BindInstance(data2);
            });
        }
    }
}