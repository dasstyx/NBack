using Pallada.Gameplay.InputStage;
using Pallada.Gameplay.Score;
using Pallada.Gameplay.Verifier;
using Zenject;

public class MissesHandler : InputHandlerBase
{
    [Inject] private IMissesScore missesScore;

    private void PlusMiss(VerifierResult.Type type)
    {
        IncrementScoreOnGood(type, missesScore);
    }

    private void Miss()
    {
        var result = Verifier.SubmitVerify();
        PlusMiss(result.type);
    }

    [Inject]
    private void Initialize(InputStage stage)
    {
        stage.SubscribeToMiss(Miss);
    }
}