using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneData : MonoBehaviour
{
    public GameObject sceneDataObj;
    public Vector3 playerDataObj;
    public GameObject ActualPrefab;
    private static bool created = false;
    private InputSystemActions inputStm;
    bool grab;

    public GameObject playerPosition;
    public int actuallife;
    public float actualmp;
    public Life playerlife;
    public MP_System playerMp;
    

    /*private void Awake()
    {
        inputStm = new InputSystemActions();
        inputStm.MenusPause.ReloadCheckpoint.canceled += ctx => grab = false;
        inputStm.MenusPause.ReloadCheckpoint.performed += ctx => SavePrefab(sceneDataObj);
        
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("D");
        }
        Debug.Log("A");

        SetPlayer();
    }

    public void SavePrefab(GameObject test)
    {
        if (sceneDataObj == null)
        {
            Debug.Log("No hay data, ve a un checkpoint");
        }
        else {
            AssetDatabase.DeleteAsset("Assets/Resources/DataSave/All.prefab");

            string localPath_0 = "Assets/Resources/DataSave/All.prefab";

            localPath_0 = AssetDatabase.GenerateUniqueAssetPath(localPath_0);

            bool prefabSuccess;
            PrefabUtility.SaveAsPrefabAsset(test, localPath_0, out prefabSuccess);
            ActualPrefab = Resources.Load("DataSave/All") as GameObject;
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            StartCoroutine(testE());
            if (prefabSuccess == true)
                Debug.Log("Prefab was saved successfully");
            else
                Debug.Log("Prefab failed to save" + prefabSuccess);
        }
        
    }

    public void SetPlayer()
    {
        ActualPrefab = Resources.Load("DataSave/All") as GameObject;
        playerPosition = GameObject.FindGameObjectWithTag("Player");
        if (ActualPrefab == null)
        {

            playerPosition = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            GameObject actual = GameObject.FindGameObjectWithTag("All");
            playerPosition = GameObject.FindGameObjectWithTag("Player");
            Destroy(actual);
            Instantiate(ActualPrefab);
            playerlife = playerPosition.GetComponent<Life>();
            playerMp = playerPosition.GetComponent<MP_System>();
            playerlife.actualHealth = actuallife;
            playerMp.actualMP = actualmp;
            playerPosition.transform.position = playerDataObj;
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
    IEnumerator testE()
    {
        yield return new WaitForSeconds(0.1f);
        playerPosition = GameObject.FindGameObjectWithTag("Player");
        SetPlayer();
    }*/
}
