using Pallada.Gameplay.Score;
using TMPro;
using UniRx;
using UnityEngine;

namespace UI.Game.ScoreView
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class ScoreView : MonoBehaviour
    {
        protected virtual IScore score { get; }

        private void Start()
        {
            var text = GetComponent<TextMeshProUGUI>();
            score.Value.Subscribe(x => text.text = x.ToString());
        }
    }
}