using Pallada.Gameplay.Score;
using Pallada.Gameplay.Verifier;
using Zenject;

public class GridClickHandler : InputHandlerBase
{
    [Inject] private IHitsScore hitsScore;
    [Inject] private IMissClicksScore missClick;

    public void Click()
    {
        var result = Verifier.SubmitVerify();
        CheckClickHit(result.type);
        CheckMissClick(result.type);
    }

    private void CheckClickHit(VerifierResult.Type type)
    {
        IncrementScoreOnGood(type, hitsScore);
    }

    private void CheckMissClick(VerifierResult.Type type)
    {
        IncrementScoreOnFailed(type, missClick);
    }
}