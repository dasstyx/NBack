using System;
using System.Collections;
using Pallada.Gameplay.TilesGrid.Entity;
using Pallada.Gameplay.TilesGrid.Randomizer;
using UniRx;

namespace Pallada.Gameplay.TilesGrid.Tiles
{
    public class TilesHighlighter
    {
        private readonly ITileRandomizer tileRandomizer;
        private Action onHighlightEnd;
        private Action<IGridEntity> onHighlightStart;


        public TilesHighlighter(ITileRandomizer tileRandomizer)
        {
            this.tileRandomizer = tileRandomizer;
        }


        public IGridEntity HighlightNext()
        {
            var tileEnumerator = tileRandomizer.GetRandomTile().GetEnumerator();

            if (tileEnumerator.MoveNext())
            {
                var tile = tileEnumerator.Current;
                HighlightTile(tile).ToObservable().Subscribe();
                return tile;
            }

            return new NullGridEntity();
        }

        private IEnumerator HighlightTile(IGridEntity tile)
        {
            onHighlightStart?.Invoke(tile);
            yield return tile.HighlightTile();
            onHighlightEnd?.Invoke();
        }

        public void SubscribeToEnd(Action onEnd)
        {
            onHighlightEnd += onEnd;
        }

        public void SubscribeToStart(Action<IGridEntity> onStart)
        {
            onHighlightStart += onStart;
        }
    }
}