using Pallada.Gameplay.GameState;

namespace Pallada.Gameplay.Verifier
{
    public class AutoVerifier
    {
        private readonly GameProcess process;
        private readonly InputStage.InputStage stage;
        private readonly Verifier verifier;

        public AutoVerifier(
            Verifier verifier,
            InputStage.InputStage stage,
            GameProcess process)
        {
            this.verifier = verifier;
            this.stage = stage;
            this.process = process;
            stage.SubscribeToStart(
                () => verifier.NewStep(stage.currentTile)
            );
        }

        public VerifierResult SubmitVerify()
        {
            var result = Verify();
            stage.StageOver();
            return result;
        }

        public VerifierResult Verify()
        {
            if (stage.stageOpen == false
                || process.isRunning == false)
            {
                return VerifierResult.GetIgnore();
            }

            return verifier.Verify();
        }
    }
}