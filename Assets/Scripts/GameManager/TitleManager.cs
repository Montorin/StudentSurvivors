using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static SaveData saveData;
    [SerializeField] GameObject UpgradeMenu;
    //
    [SerializeField] GameObject HeroChoice;
    //
    [SerializeField] GameObject MapChoice;
    //
    [SerializeField] GameObject SettingMenu;
    [SerializeField] GameObject OnButton;
    [SerializeField] GameObject OffButton;
    string SavePath => Path.Combine(Application.persistentDataPath, "save.bin");
    private void Awake()
    {
        SaveData.postprocess = true;
        if (saveData == null)
            Load();
        else
            Save();
    }
    private void Load()
    {
        FileStream file = null;
        try
        {
            file = File.Open(SavePath, FileMode.Open);
            var bf = new BinaryFormatter();
            saveData = (SaveData)bf.Deserialize(file);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            saveData = new SaveData();
        }
        finally
        {
            if (file != null) file.Close();
        }
    }
    private void Save()
    {
        FileStream file = null;
        try
        {
            if (!Directory.Exists(Application.persistentDataPath)) Directory.CreateDirectory(Application.persistentDataPath);
            file = File.Create(SavePath);
            var bf = new BinaryFormatter();
            bf.Serialize(file, saveData);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }
    public void OnStartButtonClick()
    {
        HeroChoice.SetActive(true); ;
    }
    public void OnUpgradeButtonClick()
    {
        UpgradeMenu.SetActive(true);
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
    public void OnHealthUpgrade()
    {
        if (saveData.goldCoins >= 500)
        {
            saveData.goldCoins = saveData.goldCoins - 500;
            saveData.HP_Up++;
        }
    }
    public void OnSpeedUpgrade()
    {
        if (saveData.goldCoins >= 1000)
        {
            saveData.goldCoins = saveData.goldCoins - 1000;
            saveData.Speed_Up++;
        }
    }
    public void OnPostProcess()
    {
        if (SaveData.postprocess == false)
        {
            SaveData.postprocess = true;
            OnButton.SetActive(true);
            OffButton.SetActive(false);
        }
        else
        {
            SaveData.postprocess = false;
            OnButton.SetActive(false);
            OffButton.SetActive(true);
        }
    }
    public void OnSettingButtonClick()
    {
        SettingMenu.SetActive(true);
        if (!SaveData.postprocess)
        { OffButton.SetActive(false); }
    }
    public void OnExitUpgradeMenu()
    { UpgradeMenu.SetActive(false); }
    public void OnHero1Choice()
    {
        saveData.playerChoice = 1;
        MapChoice.SetActive(true);
        HeroChoice.SetActive(false);
        if (!SaveData.unlockCastle)
        {
            SaveData.unlockCastle = false;
        }
    }
    public void OnHero2Choice()
    {
        saveData.playerChoice = 2;
        MapChoice.SetActive(true);
        HeroChoice.SetActive(false);
        if (!SaveData.unlockCastle)
        {
            SaveData.unlockCastle = false;
        }
    }
    public void OnHeroChoiceExitButtonClick()
    { HeroChoice.SetActive(false); }
    public void OnMap1ButtonClick()
    {
        saveData.sceneNumber = 0;
        SceneManager.LoadScene("game");
    }
    public void OnMap2ButtonClick()
    {
        //if (SaveData.unlockCastle == true)
        //{
        saveData.sceneNumber = 1;
        SceneManager.LoadScene("game 1");
        //}
        //else
        //{
        //    //Do Nothing
        //}
    }
    public void OnMapChoiceExitButtonClick()
    { MapChoice.SetActive(false); }
    public void OnExitSettingButtonClick()
    { SettingMenu.SetActive(false); }
}
