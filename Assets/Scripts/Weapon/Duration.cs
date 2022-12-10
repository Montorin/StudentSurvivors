using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : BaseWeapon
{
    public static int duration;
    // Update is called once per frame
    void Update()
    {
        duration = level;
    }
}
