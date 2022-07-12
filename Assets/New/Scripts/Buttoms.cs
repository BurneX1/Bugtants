using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(VolumeValue))]
public class Buttoms : MonoBehaviour
{
    public AudioSource audioFont;
    public AudioClip btmSound;

    public Animator animator;
    [Range(0, 1)]
    public float capVolume;
    public float timer;
    public bool actvOn = false;
    private string actualScene;

    public bool activeDelay = false;
    public string actualCanva;
    public float delayTimer = 0;

    private VolumeValue volumeScript;
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        actualScene = scene.name;
        audioFont.clip = btmSound;
        volumeScript = GetComponent<VolumeValue>();
    }

    private void Update()
    {
        if (audioFont.volume != volumeScript.volValue * capVolume)
            audioFont.volume = volumeScript.volValue * capVolume;
        if (actvOn)
        {
            animator.Play("FadeOut_Black");
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                SceneManager.LoadScene("PreIntroduction");
            }
        }

        Delay();
    }
    public void Restart()
    {
        SceneManager.LoadScene(actualScene);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SceneChangeMenu()
    {
        actvOn = true;
    }


    public void ShowCanvas(GameObject on)
    {
        on.SetActive(true);
    }
    public void HideCanvas(GameObject off)
    {
        off.SetActive(false);
    }


    public void ExitGame()
    {
        Application.Quit();
    }



    public void ActivateCanvas(string canvasName)
    {
        GameObject.Find(canvasName).GetComponent<Canvas>().enabled = true;
    }
    public void DeActivateCanvas(string canvasName)
    {
        GameObject.Find(canvasName).GetComponent<Canvas>().enabled = false;
    }
    public void ActivateCanvasDelay(string canvasName)
    {
        activeDelay = true;
        actualCanva = canvasName;
    }

    private void Delay()
    {
        if (activeDelay)
        {
            delayTimer += Time.deltaTime;

            if(delayTimer >= 1.1f)
            {
                GameObject.Find(actualCanva).GetComponent<Canvas>().enabled = true;
                delayTimer = 0;
                activeDelay = false;
            }
        }
    }


    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void PlaySound()
    {
        audioFont.Play();
    }
}
