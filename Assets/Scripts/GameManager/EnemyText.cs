using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyText : MonoBehaviour
{
    GameManager gamemanager;
    [SerializeField] TMP_Text enemyText;
    private void Update()
    {
        enemyText.text = TitleManager.saveData.mermandead.ToString();
    }
}
