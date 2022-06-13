using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchObjects : MonoBehaviour
{
    private InputSystemActions inputStm;
    public GameObject key1, key2;
    [HideInInspector]
    public bool activated, located;
    public GameObject[] Status_0, Status_1;
    private GameObject tutorialScribe;
    // Start is called before the first frame update
    void Awake()
    {
        tutorialScribe = GameObject.Find("Tutoria/TutorialMessage");
        inputStm = new InputSystemActions();
        activated = false;
        inputStm.GamePlay.Interact.performed += ctx => DoingActivate();
    }
    void DoingActivate()
    {
        if (located)
            Activation();
    }
    public void Activation()
    {
        if (!activated && key1 == null && key2 == null)
        {
            activated = true;
            tutorialScribe.GetComponent<Text>().text = null;
            if (Status_0.Length != 0)
            {
                foreach (GameObject off in Status_0)
                {
                    if (off != null)
                        off.SetActive(false);
                }
                if (Status_1.Length != 0)
                {
                    foreach (GameObject on in Status_1)
                    {
                        if (on != null)
                            on.SetActive(true);
                    }
                }
            }
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
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !activated)
        {
            if (key1 != null && key2 != null)
            {
                tutorialScribe.GetComponent<Text>().text = "Necesitas encontrar 2 gemas restantes";
            }
            else if(key1 != null || key2 != null)
            {
                tutorialScribe.GetComponent<Text>().text = "Necesitas encontrar 1 gema restante";
            }
            else if (key1 == null && key2 == null)
            {
                tutorialScribe.GetComponent<Text>().text = "Interactúa para avanzar";
            }
            located = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            located = false;
            tutorialScribe.GetComponent<Text>().text = null;
        }
    }
}