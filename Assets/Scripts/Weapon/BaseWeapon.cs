using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    protected int level;
    internal void LevelUp()
    {
        if(++level == 1)
        {
            gameObject.SetActive(true);
        }
    }
}
