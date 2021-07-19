using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int silverKeys;
    public static int SilverKeys
    {
        get
        {
            return silverKeys;
        }
        set
        {
            silverKeys = value;
        }
    }
}

