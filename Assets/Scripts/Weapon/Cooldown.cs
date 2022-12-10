using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : BaseWeapon
{
    public static int cooldown;
    // Update is called once per frame
    void Update()
    {
        cooldown = level;
    }
}
