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

    [Header("[Mana Stuff]")]
    public Image manaBar;
    public Text manaTxt;

    [Header("[Stamina Stuff]")]
    public Image stmBar;
    public Text stmTxt;

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
        BarRefresh(lifeBar, c_ctrll.c_life.actualHealth, c_ctrll.c_life.maxHealth, lifeTxt, "" + c_ctrll.c_life.actualHealth + "");
        BarRefresh(manaBar, c_ctrll.c_mp.actualMP, c_ctrll.c_mp.maxMP, manaTxt, "" + c_ctrll.c_mp.actualMP + "");
        BarRefresh(stmBar, c_ctrll.c_stm.actStamina, c_ctrll.c_stm.maxStamina, stmTxt, "" + c_ctrll.c_stm.actStamina + "");
    }

    private void BarRefresh(Image box, float act, float max)
    {
        if (box.fillAmount != act / max)
        {
            box.fillAmount = Mathf.Lerp(box.fillAmount, act / max, Time.deltaTime * uiReactSpd);
        }
    }
    private void BarRefresh(Image box, float act, float max, Text txt, string writeTxt)
    {
        txt.text = writeTxt;
        if (box.fillAmount != act / max)
        {
            box.fillAmount = Mathf.Lerp(box.fillAmount, act / max, Time.deltaTime * uiReactSpd);
        }
    }

}
