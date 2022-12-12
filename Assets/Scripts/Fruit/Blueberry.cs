using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueberry : MonoBehaviour
{
    private SimpleObjectPool pool;
    [SerializeField] Player player;
    private void Start()
    {
        pool = transform.parent.GetComponent<SimpleObjectPool>();
    }
    internal void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.HP = player.HP + 2;
            if (player.HP > player.MaxHP)
            {
                player.HP = 4;
            }
            pool.ReturnObject(gameObject);
        }
    }
}