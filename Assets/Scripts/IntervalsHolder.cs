using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalsHolder
{
    public static float GetDetonatorTime(float time)
    {
        switch ((int)time / 5)
        {
            case 0:
                return 3f;
            case 1:
                return 2.8f;
            case 2:
                return 2.5f;
            case 3:
                return 2.4f;
            case 4:
                return 2.3f;
            case 5:
                return 2.2f;
            case 6:
                return 2f;
            case 7:
                return 1.8f;
            case 8:
                return 1.6f;
            case 9:
                return 1.3f;
            case 10:
                return 1f;
            case 11:
                return .8f;
            case 12:
                return .6f;
            default:
                return .4f;
        }
    }

    public static float GetSpawnInterval(float time)
    {
        switch ((int)time / 5)
        {
            case 0:
                return 2f;
            case 1:
                return 1.8f;
            case 2:
                return 1.6f;
            case 3:
                return 1.4f;
            case 4:
                return 1.2f;
            case 5:
                return 1f;
            case 6:
                return .8f;
            case 7:
                return .7f;
            case 8:
                return .6f;
            case 9:
                return .5f;
            case 10:
                return .4f;
            default:
                return .3f;
        }
    }
}
