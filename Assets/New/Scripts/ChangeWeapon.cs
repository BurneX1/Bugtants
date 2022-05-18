using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ChangeWeapon : MonoBehaviour
{
    InputSystemActions inputActions;
    public Transform B_1, B_2, B_3, B_4;

    private void Awake()
    {
        inputActions = new InputSystemActions();
        inputActions.GamePlay.ChangeWeapon.performed += ctx => StartCoroutine( ChangeWepon_Logic());
    }
    IEnumerator ChangeWepon_Logic()
    {
        B_1.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        B_2.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        B_3.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        B_4.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        yield return new WaitForSeconds(1.2f);
        B_1.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        B_2.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        B_3.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        B_4.localScale = new Vector3(0.1f, 0.1f, 0.1f);
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
