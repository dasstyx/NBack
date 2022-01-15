using System.Collections;
using System.Collections.Generic;
using Pallada.Gameplay.GameState.RoundEnd;
using Pallada.Gameplay.Timer;
using UniRx;

public class RoundEnd
{
    private readonly List<IRoundEndEffect> fadeSteps;

    public RoundEnd(
        List<IRoundEndEffect> roundEndEffects,
        ITimer timer)
    {
        fadeSteps = roundEndEffects;
        timer.SubscribeOnOver(TimeOver);
    }

    public void Subscribe(IRoundEndEffect action)
    {
        fadeSteps.Add(action);
    }

    private void TimeOver()
    {
        Observable.FromCoroutine(TimeOverCoroutine)
            .Subscribe();
    }

    private IEnumerator TimeOverCoroutine()
    {
        foreach (var routine in fadeSteps)
        {
            yield return routine.Effect();
        }
    }
}