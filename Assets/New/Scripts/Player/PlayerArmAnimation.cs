using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmAnimation : MonoBehaviour
{
    public Animator pistol, shotgun;
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
        else if(playerControl.weaponNumber == 1)
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
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
}
