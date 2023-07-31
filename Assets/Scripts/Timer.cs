using System;
using UnityEngine;

public static class Timer
{
    public static Func<bool> Start(float cooldownTimeSecs)
    {
        float timeLastAttacked = 0;
        return () =>
        {
            var curTime = Time.time;
            if (curTime < timeLastAttacked + cooldownTimeSecs && timeLastAttacked != 0) return false;

            timeLastAttacked = Time.time;
            return true;
        };
    }
}