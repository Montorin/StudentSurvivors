using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathText : MonoBehaviour
{
    [SerializeField] TMP_Text deathText;
    void Update()
    {
        deathText.text = TitleManager.saveData.deathCount.ToString();
    }
}
