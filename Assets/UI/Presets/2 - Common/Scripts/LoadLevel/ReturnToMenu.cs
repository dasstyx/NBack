using Pallada.Gameplay.GameState;
using Pallada.Gameplay.GameState.GameResult;
using Zenject;

namespace UI.Presets.LoadLevel
{
    public class ReturnToMenu : LoadLevelBase
    {
        [Inject] private GameResult gameResult;

        [Inject] private GameProcess process;

        protected override string levelName => "Menu";

        public void Return(bool terminate)
        {
            if (terminate == true)
            {
                process.Terminate();
            }
            else
            {
                process.Stop();
            }

            Load(gameResult);
        }
    }
}