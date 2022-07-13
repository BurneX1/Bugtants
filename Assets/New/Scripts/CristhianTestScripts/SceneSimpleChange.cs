using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSimpleChange : MonoBehaviour
{
    [SerializeField]
    private float timer;
    public string sceneX;
    public float maxTimer;
    public bool autAct;

    public void Update()
    {

            timer += Time.deltaTime;
            if(timer >= maxTimer)
            {
                SceneManager.LoadScene(sceneX);
            }
    }


    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
