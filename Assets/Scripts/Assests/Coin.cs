using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    internal void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            TitleManager.saveData.CoinRun++;
            TitleManager.saveData.goldCoins++;
            Destroy(gameObject);
        }
    }
}
