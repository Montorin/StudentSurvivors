using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexSpawner : BaseWeapon
{
    [SerializeField] GameObject vortex;
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
                Instantiate(vortex, transform.position, Quaternion.Euler(0, 0, 0));
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(4-Cooldown.cooldown);
        }
    }
}
