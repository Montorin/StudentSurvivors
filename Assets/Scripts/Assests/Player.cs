using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject DeathMenu;
    //field == member variable
    [SerializeField] float speed = 1f;
    //
    [SerializeField] BaseWeapon[] weapon;
    //
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] RuntimeAnimatorController player2;
    //
    public int HP;
    public int MaxHP = 4;
    //
    internal int currentExp;
    internal int expToLevel = 5;
    internal int currentLevel;
    //
    bool isInvicible;
    //
    public float inputX;
    //
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (TitleManager.saveData.playerChoice == 1)
        {
            weapon[0].LevelUp();
            MaxHP = MaxHP + TitleManager.saveData.HP_Up;
            speed = speed + TitleManager.saveData.Speed_Up;
        }
        if (TitleManager.saveData.playerChoice == 2)
        {
            animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = player2;
            weapon[1].LevelUp();
            MaxHP = 3 + TitleManager.saveData.HP_Up;
            speed = 5 + TitleManager.saveData.Speed_Up;
        }
        HP = MaxHP;
    }
    //
    public bool OnDamage()
    {
        if (!isInvicible)
        {
            StartCoroutine(InvicibilityCoroutine());
            if (--HP <= 0)
            {
                TitleManager.saveData.deathCount++;
                DeathMenu.SetActive(true);
                Time.timeScale = 0;
            }
            return true;
        }
        return false;
    }
    //
    IEnumerator InvicibilityCoroutine()
    {
        isInvicible = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
        isInvicible = false;
    }
    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        if (inputX != 0)
        {
            transform.localScale = new Vector3(inputX < 0 ? -1 : 1, 1, 1);
        }

        transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;

        bool isRunning = inputX != 0 || inputY != 0;

        animator.SetBool("IsRunning", isRunning);
    }
    //
    internal void AddExp()
    {
        if (++currentExp >= expToLevel)
        {
            GameManager.levelSound = true;
            currentExp = 0;
            expToLevel += 10;
            currentLevel++;

            int totalNumberOfWeapons = weapon.Length;
            int randomIndex = Random.Range(0, totalNumberOfWeapons);

            weapon[randomIndex].LevelUp();
        }
    }
}

