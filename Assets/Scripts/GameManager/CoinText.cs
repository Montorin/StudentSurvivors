using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    GameManager gamemanager;
    [SerializeField] TMP_Text coinText;
    private void Update()
    {
        coinText.text = TitleManager.saveData.CoinRun.ToString();
    }
}
