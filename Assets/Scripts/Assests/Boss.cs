using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject target;
    [SerializeField] Enemy enemy;
    [SerializeField] GameObject DeathMenu;
    // Update is called once per frame
    void Update()
    {
        if (enemy.enemyHP <= 50)
        {
            enemy.speed = 4;
            bool lowHP = true;
            animator.SetBool("LowHP", lowHP);
        }
    }
    internal void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            TitleManager.saveData.deathCount++;
            DeathMenu.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
