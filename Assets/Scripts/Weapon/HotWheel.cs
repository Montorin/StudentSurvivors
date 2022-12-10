using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class HotWheel : BaseWeapon
{
    [SerializeField] Player player;
    float speed;
    private void Start()
    {
        speed = 150;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy)
        {
            enemy.Damage(2);
        }
    }
    void Update()
    {
        speed = 150 + 2 * level;
        transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), speed * Time.deltaTime);
        Vector3 rotationAdd = new Vector3(0, 0, 0.3f);
        transform.Rotate(rotationAdd);
        new Vector3(0, 0, 1);
    }
}
