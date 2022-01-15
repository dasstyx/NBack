using Pallada.Gameplay.GameState.GameStep;
using UnityEngine;
using Zenject;

namespace Pallada.Gameplay
{
    public class GameStarter : MonoBehaviour
    {
        [Inject] private GameStep _gameStep;

        private void Start()
        {
            _gameStep.StartLoop();
        }
    }
}