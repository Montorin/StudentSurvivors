using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image foreground;
    //
    private void Update()
    {
        if (player == null)
        {
            return;
        }
        transform.position = player.transform.position + new Vector3(0, 0.75f, 0);

        float hpRatio = (float)player.HP / player.MaxHP;

        foreground.transform.localScale = new Vector3(hpRatio, 1, 1);
    }
}
