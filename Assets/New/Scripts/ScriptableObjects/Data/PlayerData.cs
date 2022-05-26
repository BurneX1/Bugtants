using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptablePersistentObject
{
    [Header("Player Properties")]
    public int maxLife;
    public float maxStamina;
    public int maxMana;

    [Header("Player Values")]
    public float staminaRegenSpd;
    public float spd;
    public float runMultiplier;
    public float jumpHeight;
    public float crouchHeight;
    public float crouchMultiplier;
    public float crouchDelaying;
}
