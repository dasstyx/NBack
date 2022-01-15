using Pallada.Gameplay.Score;
using Pallada.Gameplay.TilesGrid.Tiles;
using Pallada.Gameplay.Verifier;

namespace Pallada.Gameplay.GameState.GameStep
{
    public class GameStep
    {
        private readonly TilesHighlighter highlighter;
        private readonly GameProcess process;
        private readonly ITotalHitsCount totalHits;

        private readonly ITotalTilesCount totalTiles;
        private readonly AutoVerifier verifier;

        public GameStep(
            TilesHighlighter highlighter,
            GameProcess process,
            AutoVerifier verifier,
            ITotalHitsCount totalHits,
            ITotalTilesCount totalTiles)
        {
            this.highlighter = highlighter;
            this.process = process;
            this.verifier = verifier;
            this.totalHits = totalHits;
            this.totalTiles = totalTiles;

            process.SubscribeUnpause(Step);
        }

        private bool stop => !process.isRunning;

        public void StartLoop()
        {
            highlighter.SubscribeToEnd(() => Step());
            Step();
        }

        private void Step()
        {
            if (stop)
            {
                return;
            }

            highlighter.HighlightNext();
            HandleTile();
        }

        private void HandleTile()
        {
            totalTiles.Plus();
            var result = verifier.Verify().type;
            if (result == VerifierResult.Type.good)
            {
                totalHits.Plus();
            }
        }
    }
}