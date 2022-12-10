using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawner : BaseWeapon
{
    [SerializeField] GameObject pool;
    private void Start()
    {
        StartCoroutine(SpawnPoolCoroutine());
        level = 1;
    }
    IEnumerator SpawnPoolCoroutine()
    {
        while (true)
        {
            Player player = GetComponent<Player>();
            for (int i = 0; i < level; i++)
            {
                Vector3 spawnPosition = Random.insideUnitCircle;
                spawnPosition += transform.position;

                Instantiate(pool, spawnPosition, Quaternion.Euler(0, 0, 0));
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(3-Cooldown.cooldown);
        }
    }
}
