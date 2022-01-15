using System.Collections.Generic;
using System.Linq;
using Pallada.Gameplay.TilesGrid.Entity;

namespace Pallada.Gameplay.Verifier
{
    public class Verifier
    {
        protected int nBack;
        protected VerifierResult result;
        protected Queue<IGridEntity> userChoices;

        public Verifier(int nBack)
        {
            this.nBack = nBack;
            userChoices = new Queue<IGridEntity>(nBack);
            result = VerifierResult.GetIgnore();
        }

        private bool IsFullStack => userChoices.Count == nBack;

        public IGridEntity GetMatchingTile()
        {
            if (IsFullStack == false)
            {
                return new NullGridEntity();
            }

            return userChoices.Peek();
        }

        public void NewStep(IGridEntity step)
        {
            VerifyBackground(step);
            if (IsFullStack)
            {
                userChoices.Dequeue();
            }

            userChoices.Enqueue(step);
        }

        public VerifierResult Verify()
        {
            return result;
        }

        private void VerifyBackground(IGridEntity target)
        {
            if (IsFullStack == false)
            {
                result = VerifierResult.GetIgnore();
                return;
            }

            var lastElement = userChoices.Peek();

            //TODO: Make a proper unit test
            var choices = userChoices
                .Select(x => x.id.ToString())
                .Aggregate((a, b) => a + "," + b);
            //Debug.Log($"{choices}\nChoosen: {target.id}");

            var equal = target.Equals(lastElement);
            if (equal)
            {
                result = VerifierResult.GetGood();
            }
            else
            {
                result = VerifierResult.GetFailed();
            }
        }
    }
}