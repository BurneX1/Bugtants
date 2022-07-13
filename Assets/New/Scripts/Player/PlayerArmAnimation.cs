using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmAnimation : MonoBehaviour
{
    public Animator pistol, shotgun, leftArm;
    public Animaters animatonsShotgun, animatonsPistol;
    private Animator anim;
    private PlayerController playerControl;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationCondition();
    }
    void AnimationCondition()
    {
        if (playerControl.weaponNumber == 0)
        {
            ChooseWeapon(shotgun);
        }
        else if (playerControl.weaponNumber == 1)
        {
            ChooseWeapon(pistol);
        }
    }
    void ChooseWeapon(Animator anim)
    {
        //anim.SetInteger("Attack", playerControl.numberMove);
        if (playerControl.numberMove == 1)
        {
            anim.SetTrigger("Shoot");
            playerControl.numberMove = 0;

        }
        else if (playerControl.numberMove == 2)
        {
            anim.SetTrigger("Melee");
            playerControl.numberMove = 0;
        }
            if (playerControl.running)
        {
            leftArm.SetBool("Running", true);
            anim.SetBool("Running", true);
        }
        else
        {
            leftArm.SetBool("Running", false);
            anim.SetBool("Running", false);
        }
    }
    public void Shooting()
    {
        leftArm.SetTrigger("Shoot");
        if (playerControl.weaponNumber == 0)
        {
            shotgun.SetTrigger("Shoot");
        }
        else if (playerControl.weaponNumber == 1)
        {
            pistol.SetTrigger("Shoot");
        }
    }
    public void MeleeDoing()
    {
        leftArm.SetTrigger("Melee");
        if (playerControl.weaponNumber == 0)
        {
            shotgun.SetTrigger("Melee");
        }
        else if (playerControl.weaponNumber == 1)
        {
            pistol.SetTrigger("Melee");
        }

    }
}

