using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeWeapon : MonoBehaviour
{
    public Transform B_1, B_2, B_3, B_4;
    public GameObject W_1, W_2;
    public int number;
    public ShootPlayer weapons;
    private Pause pauseScript;

    void Awake()
    {
        pauseScript = GameObject.FindGameObjectWithTag("Pause").GetComponent<Pause>();
    }

    IEnumerator ChangeWepon_Logic()
    {
        B_1.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        B_2.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        B_3.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        B_4.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        
        yield return new WaitForSeconds(1.5f);
        B_1.localScale = new Vector3(0f, 0f, 0f);
        B_2.localScale = new Vector3(0f, 0f, 0f);
        B_3.localScale = new Vector3(0f, 0f, 0f);
        B_4.localScale = new Vector3(0f, 0f, 0f);
        weapons.waiting = false;
    }

    public WeaponStats WeaponChanger(int id, WeaponStats[] everyWeapon, WeaponStats oldWeapon)
    {
        everyWeapon[0].weapon = W_1;
        everyWeapon[1].weapon = W_2;

        if (!weapons.waiting && number != id && !pauseScript.paused)
        {
            weapons.waiting = true;
            foreach (WeaponStats unused in everyWeapon)
            {
                unused.weapon.SetActive(false);
            }
            StartCoroutine(ChangeWepon_Logic());
            everyWeapon[id].weapon.SetActive(true);
            number = id;
            return everyWeapon[id];
        }
        else
        {
            return oldWeapon;
        }

    }
}
