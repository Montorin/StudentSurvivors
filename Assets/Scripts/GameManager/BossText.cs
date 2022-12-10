using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossText : MonoBehaviour
{
    GameManager gamemanager;
    [SerializeField] TMP_Text bossText;
    private void Update()
    {
        bossText.text = TitleManager.saveData.Bossdead.ToString();
    }
}
