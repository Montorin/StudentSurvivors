using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScythSpawner : BaseWeapon
{
    [SerializeField] GameObject scythe;
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
                Instantiate(scythe, transform.position, Quaternion.Euler(0, 0, angle));
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(4 - Cooldown.cooldown);
        }
    }
}
