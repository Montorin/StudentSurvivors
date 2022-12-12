using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private SimpleObjectPool pool;
    private void Start()
    {
        pool = transform.parent.GetComponent<SimpleObjectPool>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            Crystal.isMagnetTrue = true;
            pool.ReturnObject(gameObject);
        }
    }
}