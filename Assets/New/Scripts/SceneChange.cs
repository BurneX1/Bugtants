using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    [Tooltip("Es el nombre de la escena a donde irás")]
    public string sceneName;
    public Detecter deter;
    private InputSystemActions inputStm;

    void Awake()
    {
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Interact.performed += _ => Determinate();
    }
    void Update()
    {

    }

    void Determinate()
    {
        if (deter.touch)
        {
            SceneManager.LoadScene(sceneName);
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
}
