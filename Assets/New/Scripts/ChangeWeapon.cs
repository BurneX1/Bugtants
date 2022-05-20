using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeWeapon : MonoBehaviour
{
    InputSystemActions inputActions;
    public Transform B_1, B_2, B_3, B_4;
    public GameObject W_1, W_2;
    public int number;
    public ShootPlayer weapons;
    private void Awake()
    {
        inputActions = new InputSystemActions();



        inputActions.GamePlay.ChangeWeapon1.performed += ctx => WeaponChanger(1);
        inputActions.GamePlay.ChangeWeapon2.performed += ctx => WeaponChanger(2);
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
    void WeaponChanger(int weaponNumber)
    {
        if (!weapons.waiting)
        {
            switch (weaponNumber)
            {
                case 1:
                    if (!weapons.cannon)
                    {
                        weapons.waiting = true;
                        weapons.cannon = true;
                        W_2.SetActive(false);
                        StartCoroutine(ChangeWepon_Logic());
                        W_1.SetActive(true);

                    }
                    break;
                case 2:
                    if (weapons.cannon)
                    {
                        weapons.waiting = true;
                        weapons.cannon = false;
                        W_1.SetActive(false);
                        StartCoroutine(ChangeWepon_Logic());
                        W_2.SetActive(true);
                    }
                    break;
            }
        }
        else
        {
            return;
        }
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
