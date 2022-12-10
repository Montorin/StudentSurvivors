using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    GameObject player;
    public static bool isMagnetTrue = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        CrystalGoToPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            GameManager.crystalSound = true;
            TitleManager.saveData.ExpRun++;
            player.AddExp();
            if (isMagnetTrue == true)
            {
                StartCoroutine(MagnetDestroy());
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
    IEnumerator MagnetDestroy()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(3f);
        isMagnetTrue = false;
        gameObject.SetActive(false);
    }
    void CrystalGoToPlayer()
    {
        if (isMagnetTrue == true)
        {
            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;
            Vector3 direction;


            direction = destination - source;

            var dx = source.x - destination.x;
            var dy = source.y - destination.y;

            direction.Normalize();
            transform.position += direction * Time.deltaTime * 10;
        }
    }
}
