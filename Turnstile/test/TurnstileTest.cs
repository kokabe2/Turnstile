// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;
using Xunit;

public class TunrstileTest : IDisposable
{
    SpyTurnstileController controllerSpoof;
    Turnstile t;

    public TunrstileTest()
    {
        controllerSpoof = new SpyTurnstileController();
        t = new Turnstile(controllerSpoof);
    }

    public void Dispose()
    {
    }

    [Fact]
    public void TestInitialCondtions()
    {
        Assert.Equal(Turnstile.LOCKED, t.state);
    }

    [Fact]
    public void TestCoinInLockedState()
    {
        t.state = Turnstile.LOCKED;
        t.Event(Turnstile.COIN);
        Assert.Equal(Turnstile.UNLOCKED, t.state);
        Assert.True(controllerSpoof.UnlockCalled);
    }

    [Fact]
    public void TestCoinInUnlockedState()
    {
        t.state = Turnstile.UNLOCKED;
        t.Event(Turnstile.COIN);
        Assert.Equal(Turnstile.UNLOCKED, t.state);
        Assert.True(controllerSpoof.ThankyouCalled);
    }

    [Fact]
    public void TestPassInLockedState()
    {
        t.state = Turnstile.LOCKED;
        t.Event(Turnstile.PASS);
        Assert.Equal(Turnstile.LOCKED, t.state);
        Assert.True(controllerSpoof.AlarmCalled);
    }

    [Fact]
    public void TestPassInUnlockedState()
    {
        t.state = Turnstile.UNLOCKED;
        t.Event(Turnstile.PASS);
        Assert.Equal(Turnstile.LOCKED, t.state);
        Assert.True(controllerSpoof.LockCalled);
    }
}


class SpyTurnstileController : TurnstileController
{
    public bool LockCalled
    {
        get;
        private set;
    } = false;
    public bool UnlockCalled
    {
        get;
        private set;
    } = false;
    public bool ThankyouCalled
    {
        get;
        private set;
    } = false;
    public bool AlarmCalled
    {
        get;
        private set;
    } = false;

    public void Lock()
    {
        LockCalled = true;
    }

    public void Unlock()
    {
        UnlockCalled = true;
    }

    public void Thankyou()
    {
        ThankyouCalled = true;
    }

    public void Alarm()
    {
        AlarmCalled = true;
    }
}
