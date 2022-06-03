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
    public float opacTime;
    [Range(0.0f,1.0f)]
    public float opacValue;

    [Header("[Audio Stuff]")]
    public string runSnd;
    public string walkSnd;
    public string jumpSnd;

    private PlayerController c_ctrll;
    private Stamina c_stm;
    private Life c_life;
    private AudioManager audioMng;
    private float stmTimer=0;


    private float alphaState = 1;
    public float inactivitiMaxCounter = 20;
    public float inactivityCounter;
    public bool activateHUD = false;

    public Canvas generalCanvas;
    private void Awake()
    {
        audioMng = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        c_ctrll = gameObject.GetComponent<PlayerController>();
        c_stm = gameObject.GetComponent<Stamina>();
        c_life = gameObject.GetComponent<Life>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(uiReactSpd <=0)
        {
            uiReactSpd = 1;
        }

        inactivityCounter = inactivitiMaxCounter;
    }

    // Update is called once per frame
    void Update()
    {
        BarRefresh(lifeBar, c_ctrll.c_life.actualHealth, c_ctrll.c_life.maxHealth, lifeTxt, "" + c_ctrll.c_life.actualHealth + "");
        BarRefresh(manaBar, c_ctrll.c_mp.actualMP, c_ctrll.c_mp.maxMP, manaTxt, "" + c_ctrll.c_mp.actualMP + "");
        BarRefresh(stmBar, c_ctrll.c_stm.actStamina, c_ctrll.c_stm.maxStamina, stmTxt, "" + (int)c_ctrll.c_stm.actStamina + "");
        StmOpacity();

        AlternateOpacity();
    }

    void StmOpacity()
    {
        if (c_ctrll.c_stm.actStamina>=c_ctrll.c_stm.maxStamina)
        {
            Opac(stmBar, 0);
        }
        else
        {
            if(stmTimer < opacTime)
            {
                Opac(stmBar, 1);
                stmTimer += Time.deltaTime;
            }
            else
            {
                Opac(stmBar, opacValue);
            }
        }
    }

    private void Opac(Image box, float alpha)
    {
        if (box.color.a != alpha)
        {
            box.color = new Color(box.color.r, box.color.g, box.color.b, Mathf.Lerp(box.color.a, alpha, Time.deltaTime * uiReactSpd));
        }
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
    private void CallAudio(string name)
    {
        if(audioMng)
        {
            audioMng.PlayFx(name);
        }
    }
    private void Call3DAudio(string name)
    {
        if (audioMng)
        {

            audioMng.Set3DSound(name,gameObject);
        }
    }

    void OnDamage()
    {
        //Reproducir auch
        //Soltar Particulas
        //Cmabiar color
        //Pegarle a Ripheon

    }

    private void OnEnable()
    {
        c_stm.Reduce += ResetStmTimer;
        c_life.Damage += OnDamage;
    }
    private void OnDisable()
    {
        c_stm.Reduce -= ResetStmTimer;
    }

    void ResetStmTimer()
    {
        Debug.Log("Reset");
        stmTimer = 0;
    }

    void AlternateOpacity()
    {
        if(activateHUD == false)
        {
            inactivityCounter -= Time.deltaTime;
            if(inactivityCounter <= 0)
            {
                alphaState -= Time.deltaTime;
                if (alphaState <= 0) alphaState = 0;
                generalCanvas.GetComponent<CanvasGroup>().alpha = alphaState;
            }
        }

        if(activateHUD == true)
        {
            inactivityCounter = inactivitiMaxCounter;
            generalCanvas.GetComponent<CanvasGroup>().alpha = 1;
            activateHUD = false;
        }
    }

}
