using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private SimpleObjectPool coinpool;

    private void Start()
    {
        coinpool = transform.parent.GetComponent<SimpleObjectPool>();
    }
    internal void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            TitleManager.saveData.CoinRun++;
            TitleManager.saveData.goldCoins++;
            coinpool.ReturnObject(gameObject);
        }
    }
}
