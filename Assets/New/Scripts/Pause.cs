using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Pause : MonoBehaviour
{
    InputSystemActions inputStm;
    public bool paused;
    public float deadMaxTime;
    private float deadTime;
    public GameObject pauseHud;
    public GameObject deadScreen;
    private GameObject player;
    private MP_System mpScript;
    private Life lifeScript;
    public AudioSource pauseMusic;
    // Start is called before the first frame update

    void Awake()
    {
        inputStm = new InputSystemActions();
        player = GameObject.FindGameObjectWithTag("Player");
        inputStm.MenusPause.Pause.performed += _ => Buttoners();
        mpScript = player.GetComponent<MP_System>();
        lifeScript = player.GetComponent<Life>();
    }
    void Start()
    {
        Resume();
    }
    void Update()
    {
        DeadRate();
    }
    // Update is called once per frame
    void Buttoners()
    {
        if (lifeScript.actualHealth > 0)
        {
            if (!paused)
                Paused();
            else
                GoingBack();
        }
    }
    public void Paused()
    {
        Time.timeScale = 0;
        pauseHud.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (!paused)
        {
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
        }
        pauseMusic.Play();
        paused = true;

    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseHud.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        if (paused)
        {
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.UnPause();
            }
        }
        pauseMusic.Pause();
        paused = false;
    }
    public void GoingBack()
    {
        Button exiter = GameObject.FindGameObjectWithTag("BackResume").GetComponent<Button>();
        exiter.onClick.Invoke();
    }
    public void GodMode()
    {
        if (lifeScript.inmortal)
        {
            lifeScript.inmortal = false;
        }
        else
        {
            lifeScript.inmortal = true;
        }
        if (lifeScript.inmortal && deadTime >= deadMaxTime && lifeScript.actualHealth == 0)
        {
            deadScreen.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            if (paused)
            {
                AudioSource[] audios = FindObjectsOfType<AudioSource>();
                foreach (AudioSource a in audios)
                {
                    a.UnPause();
                }
            }
            lifeScript.actualHealth = lifeScript.maxHealth;
            pauseMusic.Pause();
            //deadMusic.Pause();
            paused = false;

            deadTime = 0;
        }

    }
    void DeadRate()
    {
        if (lifeScript.actualHealth <= 0 && !lifeScript.inmortal)
        {
            deadTime+=Time.deltaTime;
            if (deadTime >= deadMaxTime)
            {
                deadScreen.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                if (!paused)
                {
                    AudioSource[] audios = FindObjectsOfType<AudioSource>();
                    foreach (AudioSource a in audios)
                    {
                        a.Pause();
                    }
                }
                //deadMusic.Play();
                paused = true;
            }
        }
        else if (deadTime != 0)
        {
            deadTime = 0;
        }
    }
    private void OnEnable()
    {
        inputStm.Enable();
    }

    private void OnDisable()
    {
        inputStm.Disable();
    }
    public void Recharge()
    { 
        mpScript.FullRecharge(); 
    }
}
