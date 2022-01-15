using Pallada.Gameplay.Score;
using Pallada.Gameplay.Verifier;
using Zenject;

public abstract class InputHandlerBase
{
    protected AutoVerifier Verifier { get; private set; }

    protected void IncrementScoreOnGood(VerifierResult.Type type, IScore score)
    {
        if (ShouldIgnore(type))
        {
            return;
        }
        if (type == VerifierResult.Type.good)
        {
            score.Plus();
        }
    }
    
    protected void IncrementScoreOnFailed(VerifierResult.Type type, IScore score)
    {
        if (ShouldIgnore(type))
        {
            return;
        }
        if (type == VerifierResult.Type.failed)
        {
            score.Plus();
        }
    }

    private bool ShouldIgnore(VerifierResult.Type type) => type == VerifierResult.Type.ignore;

    [Inject]
    private void Initialize(AutoVerifier verifier)
    {
        Verifier = verifier;
    }
}