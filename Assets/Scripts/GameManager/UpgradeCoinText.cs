using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeCoinText : MonoBehaviour
{
    [SerializeField] TMP_Text coinText;
    void Update()
    {
        coinText.text = TitleManager.saveData.goldCoins.ToString();
    }
}