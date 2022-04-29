using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [Header("[General Stuff]")]
    [Range(1,10)]
    public float uiReactSpd;

    [Header("[Life Stuff]")]
    public Image lifeBar;
    public Text lifeTxt;


    [Tooltip("This attribute would be diseabled in code while MP_System script still manage the maná UI")]
    [Header("[Mana Stuff]")]
    public Image manaBar;
    [Tooltip("This attribute would be diseabled in code while MP_System script still manage the maná UI")]
    public Text manaTxt;

    private PlayerController c_ctrll;

    private void Awake()
    {
        c_ctrll = gameObject.GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(uiReactSpd <=0)
        {
            uiReactSpd = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        LifeRefresh();
        //ManaRefresh()
    }

    private void LifeRefresh()
    {
        lifeTxt.text = "" + c_ctrll.c_life.actualHealth + "";
        float act = c_ctrll.c_life.actualHealth;
        float max = c_ctrll.c_life.maxHealth;
        if(lifeBar.fillAmount != act / max)
        {
            lifeBar.fillAmount =   Mathf.Lerp(lifeBar.fillAmount, act / max,Time.deltaTime*uiReactSpd);
        }
    }
    private void ManaRefresh()
    {
        manaTxt.text = "" + c_ctrll.c_life.actualHealth + "";
        float act = c_ctrll.c_mp.ActualMP;
        float max = c_ctrll.c_mp.MaxMP;
        if (manaBar.fillAmount != act / max)
        {
            manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, act / max, Time.deltaTime * uiReactSpd);
        }
    }

}
