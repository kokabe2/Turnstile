// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;

public class Turnstile
{
    // state
    public static readonly int LOCKED = 0;
    public static readonly int UNLOCKED = 1;

    // event
    public static readonly int COIN = 0;
    public static readonly int PASS = 1;

    public int state = LOCKED;  // private

    public Turnstile(TurnstileController action)
    {
    }

    public void Event(int e)
    {
    }
}
