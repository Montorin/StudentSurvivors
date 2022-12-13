using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Apple : MonoBehaviour
{
    [SerializeField] SimpleObjectPool pool;
    [SerializeField] Player player;
    internal void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.HP++;
            if (player.HP > player.MaxHP)
            {
                player.HP = 4;
            }
            pool.ReturnObject(gameObject);
        }
    }
}
