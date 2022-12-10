using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public static GameManager gamemanager;
    //
    [SerializeField] GameObject crystalPrefab;
    [SerializeField] GameObject apple;
    [SerializeField] GameObject blueberry;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject magnet;
    [SerializeField] int hp;
    //
    GameObject target;
    GameObject boss;
    //
    public float speed = 1f;
    //
    public bool isTrackingPlayer = true;
    //
    public int enemyHP;
    //
    [SerializeField] SpriteRenderer spriteRenderer;
    //
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (target == null)
        {
            return;
        }
        Vector3 destination = target.transform.position;
        Vector3 source = transform.position;

        Vector3 direction = destination - source;

        if (!isTrackingPlayer)
        {
            direction = new Vector3(1, 0, 0);
        }

        direction.Normalize();

        transform.position += direction * speed * Time.deltaTime;

        transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);
    }
    internal void Damage(int damage)
    {
        float enemyX = enemy.transform.position.x;
        float enemyY = enemy.transform.position.y;
        float enemyZ = enemy.transform.position.z;
        //
        enemyHP -= damage;
        //
        if (enemyHP <= 0)
        {
            // Heal (25% chance-8%)
            int randomRange = Random.Range(0, 100);
            if (randomRange < 8)
            {
                Vector3 applePosition = new Vector3(enemyX, enemyY + (float)0.1, enemyZ);
                apple.transform.position = transform.position;
                apple.transform.rotation = Quaternion.Euler(0, 0, 0);
                apple.SetActive(true);
            }
            // Heal (50% chance-3%)
            else if (randomRange > 96)
            {
                Vector3 berryPostion = new Vector3(enemyX, enemyY + (float)0.1, enemyZ);
                blueberry.transform.position = transform.position;
                blueberry.transform.rotation = Quaternion.Euler(0, 0, 0);
                blueberry.SetActive(true);
            }
            // Coin (chance-5%)
            int randomRanger = Random.Range(0, 101);
            if (randomRanger < 5)
            {
                Vector3 coinPosition = new Vector3(enemyX + (float)0.2, enemyY + (float)0.2, enemyZ);
                coin.transform.position = transform.position;
                coin.transform.rotation = Quaternion.identity;
                coin.SetActive(true);
            }
            // Magnet (chance-1%)
            int randomRanger2 = Random.Range(0, 101);
            if (randomRanger2 < 1)
            {
                Vector3 magnetPosition = new Vector3(enemyX + (float)-0.2, enemyY + (float)-0.2, enemyZ);
                magnet.transform.position = transform.position;
                magnet.transform.rotation = Quaternion.identity;
                magnet.SetActive(true);
            }
            // EXP
            Vector3 enemyPosition = new Vector3(enemyX + (float)0.2, enemyY + (float)0.2, enemyZ);
            crystalPrefab.transform.position = transform.position;
            crystalPrefab.transform.rotation = Quaternion.identity;
            crystalPrefab.SetActive(true);
            if (gameObject.name.Contains("Boss"))
            {
                TitleManager.saveData.Bossdead++;
            }
            else
            {
                TitleManager.saveData.mermandead++;
            }
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            if (player.OnDamage())
            {
                gameObject.SetActive(false);
            }
        }
    }
}
