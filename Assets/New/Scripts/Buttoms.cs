using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttoms : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
}
