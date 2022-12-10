using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : BaseWeapon
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider2D;
    //
    private void Start()
    {
        StartCoroutine(KatanaAttack());
    }
    private IEnumerator KatanaAttack()
    {
        while (true)
        {
            transform.localScale = Vector3.one * (level*0.5f+0.5f);

            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            boxCollider2D.enabled = true;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(3 - Cooldown.cooldown);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(1);
        }
    }
}
