using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Pause : MonoBehaviour
{
    InputSystemActions inputStm;
    public bool paused;
    public GameObject pauseHud;
    private MP_System mpScript;
    // Start is called before the first frame update

    void Awake()
    {
        inputStm = new InputSystemActions();
        inputStm.MenusPause.Pause.performed += _ => Buttoners();
        mpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MP_System>();
    }
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Buttoners()
    {
        if (!paused)
            Paused();
        else
            GoingBack();


    }
    public void Paused()
    {
        Time.timeScale = 0;
        pauseHud.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        paused = true;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach(AudioSource a in audios)
        {
            a.Pause();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseHud.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }
    public void GoingBack()
    {
        Button exiter = GameObject.FindGameObjectWithTag("BackResume").GetComponent<Button>();
        exiter.onClick.Invoke();
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
