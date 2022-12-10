using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : BaseWeapon
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            if(level >= 5)
            {
                enemy.Damage((int)1);
            }
            else
            {
            enemy.Damage((int)0.5);
            }
        }
    }
}
