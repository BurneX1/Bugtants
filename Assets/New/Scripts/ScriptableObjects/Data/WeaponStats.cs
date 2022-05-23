using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponStats", menuName = "Weapons/WeaponStats")]
public class WeaponStats : ScriptableObject
{
    [Header("Weapon Properties")]
    public int damage;
    public float fireRate, bulletSpeed, mpCost;
    public GameObject weapon, bulletType;
}
