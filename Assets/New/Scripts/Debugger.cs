using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    [Header("All Datas")]
    public PlayerData playerStats;
    public WeaponStats shotgunStats, pistolStats;
    [Header("Any transition")]
    public GameObject[] parts;

    public InputField[] playerField, shotgunField, pistolField, meleeField, smokeField, midDistField, stunnerField, huggerField, queenBugField;

    private int debugNumber = 0;
    void Awake()
    {
        playerField = new InputField[10];
        for (int i = 0; i < playerField.Length; i++)
        {
            playerField[i] = GameObject.Find("PlayerPart/InputField " + "(" + i + ")").GetComponent<InputField>();
        }

        //

        playerField[0].text = "" + playerStats.maxLife;
        playerField[1].text = "" + playerStats.maxStamina;
        playerField[2].text = "" + playerStats.maxMana;
        playerField[3].text = "" + playerStats.staminaRegenSpd;
        playerField[4].text = "" + playerStats.spd;
        playerField[5].text = "" + playerStats.runMultiplier;
        playerField[6].text = "" + playerStats.jumpHeight;
        playerField[7].text = "" + playerStats.crouchHeight;
        playerField[8].text = "" + playerStats.crouchMultiplier;
        playerField[9].text = "" + playerStats.crouchDelaying;

        //

        shotgunField = new InputField[4];
        for (int i = 0; i < shotgunField.Length; i++)
        {
            shotgunField[i] = GameObject.Find("ShotgunPart/InputField " + "(" + i + ")").GetComponent<InputField>();
        }
        //

        shotgunField[0].text = "" + shotgunStats.damage;
        shotgunField[1].text = "" + shotgunStats.fireRate;
        shotgunField[2].text = "" + shotgunStats.bulletSpeed;
        shotgunField[3].text = "" + shotgunStats.mpCost;

        //

        pistolField = new InputField[4];
        for (int i = 0; i < pistolField.Length; i++)
        {
            pistolField[i] = GameObject.Find("PistolPart/InputField " + "(" + i + ")").GetComponent<InputField>();
        }

        //

        pistolField[0].text = "" + pistolStats.damage;
        pistolField[1].text = "" + pistolStats.fireRate;
        pistolField[2].text = "" + pistolStats.bulletSpeed;
        pistolField[3].text = "" + pistolStats.mpCost;

        //
        Transition(0);
    }

    public void Transition(int value)
    {
        debugNumber += value;
        while (debugNumber >= parts.Length)
        {
            debugNumber -= parts.Length;
        }
        while (debugNumber < 0)
        {
            debugNumber += parts.Length;
        }
        for (int i = 0; i < parts.Length; i++)
        {
            if (i != debugNumber)
                parts[i].SetActive(false);
            else
                parts[i].SetActive(true);
        }


    }

    void Update()
    {
        NumberChange();
    }
    void NumberChange()
    {
        PlayerStat(0, 0);
        ShotgunStat(0, 0);
        PistolStat(0, 0);

    }
    void PlayerStat(int integer, float value)
    {
        int.TryParse(playerField[0].text, out integer);
        playerStats.maxLife = integer;
        float.TryParse(playerField[1].text, out value);
        playerStats.maxStamina = value;
        int.TryParse(playerField[2].text, out integer);
        playerStats.maxMana = integer;

        float.TryParse(playerField[3].text, out value);
        playerStats.staminaRegenSpd = value;
        float.TryParse(playerField[4].text, out value);
        playerStats.spd = value;
        float.TryParse(playerField[5].text, out value);
        playerStats.runMultiplier = value;
        float.TryParse(playerField[6].text, out value);
        playerStats.jumpHeight = value;
        float.TryParse(playerField[7].text, out value);
        playerStats.crouchHeight = value;
        float.TryParse(playerField[8].text, out value);
        playerStats.crouchMultiplier = value;
        float.TryParse(playerField[9].text, out value);
        playerStats.crouchDelaying = value;

    }

    void ShotgunStat(int integer, float value)
    {

        int.TryParse(shotgunField[0].text, out integer);
        shotgunStats.damage = integer;
        float.TryParse(shotgunField[1].text, out value);
        shotgunStats.fireRate = value;
        float.TryParse(shotgunField[2].text, out value);
        shotgunStats.bulletSpeed = value;
        float.TryParse(shotgunField[3].text, out value);
        shotgunStats.mpCost = value;
    }
    void PistolStat(int integer, float value)
    {

        int.TryParse(pistolField[0].text, out integer);
        pistolStats.damage = integer;
        float.TryParse(pistolField[1].text, out value);
        pistolStats.fireRate = value;
        float.TryParse(pistolField[2].text, out value);
        pistolStats.bulletSpeed = value;
        float.TryParse(pistolField[3].text, out value);
        pistolStats.mpCost = value;
    }
    void MeleeStat(int integer, float value)
    {

    }
    void SmokeStat(int integer, float value)
    {

    }
    void MidDistStat(int integer, float value)
    {

    }
    void StunnerStat(int integer, float value)
    {

    }
    void ExploderStat(int integer, float value)
    {

    }
    void HuggerStat(int integer, float value)
    {

    }

    void BugtantQueenStat(int integer, float value)
    {

    }

    public void PlayerConfirm()
    {
        PlayerController character;
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        character.LoadData();
    }
    public void WeaponConfirm()
    {
        PlayerController weaponish;
        weaponish = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        weaponish.LoadWeapon();
    }
}
