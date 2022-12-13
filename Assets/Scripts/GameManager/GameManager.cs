using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text TimerText;
    [SerializeField] TMP_Text coinText;
    [SerializeField] private SimpleObjectPool merman;
    [SerializeField] private SimpleObjectPool zombie;
    [SerializeField] private SimpleObjectPool rusher;
    [SerializeField] GameObject player;
    [SerializeField] private SimpleObjectPool boss;
    [SerializeField] Player Player;
    [SerializeField] AudioSource crystalSource;
    [SerializeField] AudioSource levelSource;
    //
    public static bool crystalSound = false;
    public static bool levelSound = false;
    //
    int spawnCounter = 1;
    //
    public int sceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawmEnemyCoroutine());
    }
    private void Update()
    {
        if (crystalSound == true)
        {
            crystalSource.Play();
            crystalSound = false;
        }
        if (levelSound == true)
        {
            levelSource.Play();
            levelSound = false;
        }
        int minutes;
        int seconds = (int)Time.timeSinceLevelLoad;
        minutes = seconds / 60;
        if (minutes >= 1)
        {
            minutes = seconds / 60;
            seconds = Mathf.FloorToInt(seconds % 60);
        }
        if (seconds < 10 && minutes < 10)
        {
            TimerText.text = "0" + minutes.ToString() + ":" + "0" + seconds.ToString();
        }
        else if (seconds < 10)
        {
            TimerText.text = minutes.ToString() + ":" + "0" + seconds.ToString();
        }
        else if (minutes < 10)
        {
            TimerText.text = "0" + minutes.ToString() + ":" + seconds.ToString();
        }
        //
        if (player == null)
        {
            TitleManager.saveData.deathCount++;
            SceneManager.LoadScene("Title");
        }
        coinText.text = TitleManager.saveData.goldCoins.ToString();
    }
    private IEnumerator SpawmEnemyCoroutine()
    {
        if (sceneNumber == 0)
        {
            SpawnEnemies(merman, 5);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(zombie, 5);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(merman, 7);
            yield return new WaitForSeconds(6f);
            SpawnEnemies(merman, 5);
            SpawnEnemies(zombie, 5);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(merman, 9);
            yield return new WaitForSeconds(7f);//31 seconds
            SpawnEnemies(merman, 7);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(zombie, 6);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(zombie, 6);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(zombie, 6);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(zombie, 6);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(zombie, 6);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(zombie, 6);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(merman, 12);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(zombie, 6);
            yield return new WaitForSeconds(4f);//1 minute
            SpawnEnemies(merman, 14);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(rusher, 40);
            SpawnEnemies(zombie, 25);
            yield return new WaitForSeconds(12f);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(16f);//40 seconds
            SpawnEnemies(merman, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 15);
            yield return new WaitForSeconds(2f);//2 minutes
            SpawnEnemies(zombie, 10);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(rusher, 20);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(rusher, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(rusher, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 25);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(zombie, 13);
            yield return new WaitForSeconds(6f);
            SpawnEnemies(merman, 16);
            yield return new WaitForSeconds(6f);//32 seconds
            SpawnEnemies(merman, 11);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(merman, 7);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(zombie, 7);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(zombie, 7);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(zombie, 8);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(zombie, 8);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(zombie, 9);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(zombie, 9);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(zombie, 10);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(zombie, 10);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(zombie, 11);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(zombie, 11);
            yield return new WaitForSeconds(1f);//3 minutes
            SpawnEnemies(zombie, 12);
            yield return new WaitForSeconds(12f);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(zombie, 24);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(zombie, 28);
            yield return new WaitForSeconds(5f);//32 seconds
            SpawnEnemies(merman, 33);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(merman, 32);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 20);
            yield return new WaitForSeconds(3f);//4 minutes
            SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 20);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(merman, 20);
            SpawnEnemies(zombie, 30);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(zombie, 50);
            SpawnEnemies(merman, 10);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(merman, 10);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(zombie, 22);
            yield return new WaitForSeconds(5f);//30 seconds
            SpawnEnemies(zombie, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 30);
            yield return new WaitForSeconds(6f);
            SpawnEnemies(merman, 25);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 25);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(boss, 1);
            yield return new WaitForSeconds(3f);
            SaveData.unlockCastle = true;
        }
        if (sceneNumber == 1)
        {
            SpawnEnemies(zombie, 5);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(merman, 5);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(zombie, 7);
            yield return new WaitForSeconds(6f);
            SpawnEnemies(zombie, 5);
            SpawnEnemies(merman, 5);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(zombie, 9);
            yield return new WaitForSeconds(7f);//31 seconds
            SpawnEnemies(zombie, 7);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(merman, 6);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(merman, 6);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(merman, 6);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(merman, 6);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(merman, 6);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(merman, 6);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(zombie, 12);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(merman, 6);
            yield return new WaitForSeconds(4f);//1 minute
            SpawnEnemies(zombie, 14);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(rusher, 40);
            SpawnEnemies(merman, 25);
            yield return new WaitForSeconds(12f);
            SpawnEnemies(zombie, 20);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(merman, 15);
            yield return new WaitForSeconds(16f);//40 seconds
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 15);
            yield return new WaitForSeconds(2f);//2 minutes
            SpawnEnemies(merman, 10);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(rusher, 20);
            yield return new WaitForSeconds(2f);
            SpawnEnemies(rusher, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(rusher, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 25);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(merman, 13);
            yield return new WaitForSeconds(6f);
            SpawnEnemies(zombie, 16);
            yield return new WaitForSeconds(6f);//32 seconds
            SpawnEnemies(zombie, 11);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(zombie, 7);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(merman, 7);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(merman, 7);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(merman, 8);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(merman, 8);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(merman, 9);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(merman, 9);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(merman, 10);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(merman, 10);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(merman, 11);
            yield return new WaitForSeconds(1f);
            SpawnEnemies(merman, 11);
            yield return new WaitForSeconds(1f);//3 minutes
            SpawnEnemies(merman, 12);
            yield return new WaitForSeconds(12f);
            SpawnEnemies(zombie, 20);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(zombie, 20);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(merman, 24);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(merman, 28);
            yield return new WaitForSeconds(5f);//32 seconds
            SpawnEnemies(zombie, 33);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(zombie, 32);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(3f);//4 minutes
            SpawnEnemies(zombie, 20);
            SpawnEnemies(merman, 20);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(zombie, 20);
            SpawnEnemies(merman, 30);
            yield return new WaitForSeconds(8f);
            SpawnEnemies(merman, 50);
            SpawnEnemies(zombie, 10);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(zombie, 10);
            yield return new WaitForSeconds(5f);
            SpawnEnemies(merman, 22);
            yield return new WaitForSeconds(5f);//30 seconds
            SpawnEnemies(merman, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 30);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(merman, 30);
            yield return new WaitForSeconds(6f);
            SpawnEnemies(zombie, 25);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(zombie, 25);
            yield return new WaitForSeconds(3f);
            SpawnEnemies(boss, 1);
            yield return new WaitForSeconds(3f);
        }
        while (true)
        {
            SpawnEnemies(merman, 15 * spawnCounter, true);
            yield return new WaitForSeconds(4f);
            SpawnEnemies(zombie, 15 * spawnCounter, true);
            yield return new WaitForSeconds(4f);
            spawnCounter++;
        }
    }
    void SpawnEnemies(SimpleObjectPool enemyPrefab, int numberOfEnemies, bool isTracking = true)
    {
        if (player == null)
        {
            return;
        }
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int diceY = Random.Range(-1, 2);
            int diceX = Random.Range(-16, -15);

            Vector3 spawnPosition = Random.insideUnitCircle.normalized * 8;

            if (!isTracking)
            {
                spawnPosition = new Vector3(diceX, diceY, 0);
            }
            
            spawnPosition += player.transform.position;
            GameObject g = enemyPrefab.GetObject();
            g.transform.position = spawnPosition;
            g.transform.rotation = Quaternion.identity;
            g.transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
            g.SetActive(true);
        }
    }
    public void OnRestartButtonClick()
    {
        TitleManager.saveData.mermandead = 0;
        TitleManager.saveData.Bossdead = 0;
        TitleManager.saveData.CoinRun = 0;
        TitleManager.saveData.ExpRun = 0;
        Time.timeScale = 1;
        if (TitleManager.saveData.sceneNumber == 0)
        {
            SceneManager.LoadScene("Game");
        }
        if (TitleManager.saveData.sceneNumber == 1)
        {
            SceneManager.LoadScene("Game 1");
        }
    }
    public void OnMainMenuButtonClick()
    {
        TitleManager.saveData.mermandead = 0;
        TitleManager.saveData.Bossdead = 0;
        TitleManager.saveData.CoinRun = 0;
        TitleManager.saveData.ExpRun = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
}
