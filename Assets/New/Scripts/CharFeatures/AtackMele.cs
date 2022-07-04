using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackMele : MonoBehaviour
{
    public string[] dmgTagsArray;
    public int dmg;
    public GameObject hitBox;
    public float delayStartatack;
    public float atkDuration;

    [HideInInspector]
    public bool attacked;
    private float dlyTimer;
    private float atkTimer;
    private bool isAtacking;
    private DamageOnTriger hitScrp;
    public WaysToSound meleeSound;
    private void Awake()
    {
        meleeSound.whereSound = 4;
        meleeSound.whatSound = 6;
        hitScrp = hitBox.AddComponent<DamageOnTriger>();
        hitScrp.damage = dmg;
        hitScrp.dmgTagsArray = dmgTagsArray;
        hitScrp.timePerDmg = 1.5f;

        hitBox.gameObject.SetActive(false);
        isAtacking = false;
        dlyTimer = 0;
        atkTimer = 0;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DelayAtack();
    }

    void DelayAtack()
    {
        if(isAtacking== true)
        {
            if(dlyTimer < delayStartatack)
            {
                dlyTimer += Time.deltaTime;
            }
            else
            {
                
                if (hitBox.activeSelf == false)
                {
                    hitBox.SetActive(true);
                }

                if (atkTimer < atkDuration)
                {
                    atkTimer += Time.deltaTime;
                    attacked = true;
                }
                else
                {
                    hitBox.SetActive(false);
                    dlyTimer = 0;
                    atkTimer = 0;
                    if (hitScrp.doDmg)
                    {
                        meleeSound.StopThenActive();
                        hitScrp.doDmg = false;
                    }
                    isAtacking = false;
                }
            }
        }
    }

    public void Attack()
    {
        isAtacking = true;
    }

    public void CancelAtk()
    {
        if (hitBox.activeSelf == true)
        {
            hitBox.SetActive(false);
        }
        dlyTimer = 0;
        atkTimer = 0;
        isAtacking = false;
    }
}
