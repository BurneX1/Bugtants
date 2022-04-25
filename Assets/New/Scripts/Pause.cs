using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Update()
    {

    }
    void Buttoners()
    {
        Paused();
    }
    public void Paused()
    {
        Time.timeScale = 0;
        pauseHud.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        paused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseHud.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        paused = false;
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
