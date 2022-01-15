using Pallada.Gameplay.TilesGrid.Entity;

namespace Pallada.Gameplay.TilesGrid.Randomizer
{
    public class ChooseRightTile
    {
        private readonly Verifier.Verifier verifier;

        public ChooseRightTile(Verifier.Verifier verifier)
        {
            this.verifier = verifier;
        }

        public IGridEntity GetTile()
        {
            return verifier.GetMatchingTile();
        }
    }
}