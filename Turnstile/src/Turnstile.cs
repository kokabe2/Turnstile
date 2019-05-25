// Copyright(c) 2019 Ken Okabe
// This software is released under the MIT License, see LICENSE.
using System;

public class Turnstile
{
    // state
    public const int LOCKED = 0;
    public const int UNLOCKED = 1;

    // event
    public const int COIN = 0;
    public const int PASS = 1;

    public int state = LOCKED;  // private
    TurnstileController controller;

    public Turnstile(TurnstileController action)
    {
        controller = action;
    }

    public void Event(int e)
    {
        switch (state)
        {
            case LOCKED:
                switch (e)
                {
                    case COIN:
                        state = UNLOCKED;
                        controller.Unlock();
                        break;
                    case PASS:
                        controller.Alarm();
                        break;
                }
                break;
            case UNLOCKED:
                switch (e)
                {
                    case COIN:
                        controller.Thankyou();
                        break;
                    case PASS:
                        state = LOCKED;
                        controller.Lock();
                        break;
                }
                break;
        }
    }
}
