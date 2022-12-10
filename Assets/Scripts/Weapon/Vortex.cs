using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Vortex : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    GameObject target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
        StartCoroutine(VortexDestroy());
    }
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Enemy");
        }
        Vector3 destination = target.transform.position;
        Vector3 source = transform.position;

        Vector3 direction = destination - source;
        direction.Normalize();

        transform.position += direction * speed * Time.deltaTime;

        transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);
    }
    IEnumerator VortexDestroy()
    {
        yield return new WaitForSeconds(2 + Duration.duration);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.Damage(3);
        }
    }
}
