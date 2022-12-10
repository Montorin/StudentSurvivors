using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;

public class Scythe : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ScytheDestroy());
    }
    void RotateByDegrees()
    {
        Vector3 rotationToAdd = new Vector3(0, 0, 0.3f);
        transform.Rotate(rotationToAdd);
    }
    void Update()
    {
        RotateByDegrees();
        transform.position += transform.up * 5 * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(2);
        }
    }
    IEnumerator ScytheDestroy()
    {
        yield return new WaitForSeconds(2 + Duration.duration);
        gameObject.SetActive(false);
    }
}
