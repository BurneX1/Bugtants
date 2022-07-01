using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttoms : MonoBehaviour
{
    public AudioSource audioFont;
    public AudioClip btmSound;

    public Animator animator;
    public float timer;
    public bool actvOn = false;
    private string actualScene;
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        actualScene = scene.name;
        audioFont.clip = btmSound;
    }

    private void Update()
    {
        if(actvOn)
        {
            animator.Play("FadeOut_Black");
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                SceneManager.LoadScene("TestMenu");
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
