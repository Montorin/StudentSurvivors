using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpText : MonoBehaviour
{
    GameManager gamemanager;
    [SerializeField] TMP_Text expText;
    private void Update()
    {
        expText.text = TitleManager.saveData.ExpRun.ToString();
    }
}
