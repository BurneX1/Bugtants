using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckPointData : MonoBehaviour
{
    public GameObject playerData;
    public GameObject allSceneData;
    public SceneData testobj;
    private InputSystemActions inputStm;
    bool grab;
    private void Awake()
    {
        inputStm = new InputSystemActions();
        inputStm.GamePlay.Interact.canceled += ctx => grab = false;
        inputStm.GamePlay.Interact.performed += ctx => grab = true;

    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player" && grab)
        {
            playerData = col.gameObject;
            allSceneData = GameObject.FindGameObjectWithTag("All");

            testobj = GameObject.FindGameObjectWithTag("SceneData").GetComponent<SceneData>();

            testobj.sceneDataObj = allSceneData;
            testobj.playerDataObj = playerData.transform.position;
            testobj.actuallife = playerData.GetComponent<Life>().actualHealth;
            testobj.actualmp = playerData.GetComponent<MP_System>().actualMP;
            //Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
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
