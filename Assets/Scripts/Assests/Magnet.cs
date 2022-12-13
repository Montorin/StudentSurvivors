using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField]  SimpleObjectPool pool;
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