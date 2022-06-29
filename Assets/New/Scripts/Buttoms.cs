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

    private void Start()
    {
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

    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void PlaySound()
    {
        audioFont.Play();
    }
}
