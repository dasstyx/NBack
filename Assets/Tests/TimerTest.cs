using System.Collections;
using NUnit.Framework;
using Pallada.Gameplay.Timer;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

[TestFixture]
public class TimerTest : ZenjectUnitTestFixture
{
    [UnityTest]
    public IEnumerator TwoSecondsTest()
    {
        var waitUntill = 2;
        var ticks = 0;
        var timer = MakeTimer(waitUntill);

        timer.SubscribeTimer(x => ticks++);
        timer.StartTimer();

        yield return new WaitForSeconds(waitUntill);

        Assert.AreEqual(waitUntill, ticks);
    }

    [UnityTest]
    public IEnumerator CheckOver()
    {
        var waitUntill = 1;
        var done = false;
        var timer = MakeTimer(waitUntill);
        timer.SubscribeOnOver(() => OnOver(ref done));
        timer.StartTimer();

        yield return new WaitForSeconds(waitUntill);
        if (done == false)
        {
            Assert.Fail();
        }
    }

    private ITimer MakeTimer(int waitUntill)
    {
        Container.Bind<int>().FromInstance(waitUntill);
        Container.Bind<ITimer>().To<Timer>().AsSingle();
        var timer = Container.Resolve<ITimer>();
        return timer;
    }

    private void OnOver(ref bool done)
    {
        done = true;
    }
}