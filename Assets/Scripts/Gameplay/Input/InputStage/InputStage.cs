using System;
using Pallada.Gameplay.TilesGrid.Entity;
using Pallada.Gameplay.TilesGrid.Tiles;

namespace Pallada.Gameplay.InputStage
{
    public class InputStage
    {
        private Action onMiss;
        private Action onStart;

        public InputStage(TilesHighlighter highlighter)
        {
            highlighter.SubscribeToStart(StageStart);
            highlighter.SubscribeToEnd(CheckMiss);
        }

        public IGridEntity currentTile { get; private set; }
        public bool stageOpen { get; private set; }

        public void StageOver()
        {
            if (stageOpen == false)
            {
                return;
            }

            stageOpen = false;
        }

        public void SubscribeToMiss(Action action)
        {
            onMiss += action;
        }

        public void SubscribeToStart(Action action)
        {
            onStart += action;
        }

        private void CheckMiss()
        {
            if (stageOpen == false)
            {
                return;
            }

            onMiss?.Invoke();
        }

        private void StageStart(IGridEntity tile)
        {
            stageOpen = true;
            currentTile = tile;
            onStart?.Invoke();
        }
    }
}