using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScythSpawner : BaseWeapon
{
    [SerializeField] GameObject scythe;
    [SerializeField] SimpleObjectPool pool;
    private void Start()
    {
        StartCoroutine(SpawnScytheCoroutine());
        level = 1;
    }
    IEnumerator SpawnScytheCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < level; i++)
            {
                float angle = Random.Range(0, 360);
                var scythe = pool.Get();
                scythe.transform.position = transform.position;
                scythe.transform.rotation = Quaternion.Euler(0, 0, angle);
                scythe.SetActive(true);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(4 - Cooldown.cooldown);
        }
    }
}
