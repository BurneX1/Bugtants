using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(BoxCollider))]
public class EventUI : MonoBehaviour
{
    InputSystemActions inputActions;
    public string tutorialDialogue;
    [Tooltip("0 = movimiento, 1 = salto, 2 = ataques, 3 = correr, 4 = agachar, 5 = interactuar, 6 = cambiar de arma")]
    public int numberOfKey;
    public Vector3 colliderSize;
    private GameObject tutorialScribe;
    private bool touched;
    // WASD, Space, click izquierdo o click derecho, shift, ctrl, e, 1 y 2 
    void Awake()
    {
        inputActions = new InputSystemActions();
        touched = false;
        tutorialScribe = GameObject.Find("Tutoria/TutorialMessage");
        inputActions.GamePlay.Movement.performed += ctx => Measure(0);
        inputActions.GamePlay.Jump.performed += ctx => Measure(1);
        inputActions.GamePlay.Atack.performed += ctx => Measure(2);
        inputActions.GamePlay.MeleAtack.performed += ctx => Measure(2);
        inputActions.GamePlay.Run.performed += ctx => Measure(3);
        inputActions.GamePlay.Crouch.performed += ctx => Measure(4);
        inputActions.GamePlay.Interact.performed += ctx => Measure(5);
        inputActions.GamePlay.ChangeWeapon1.performed += ctx => Measure(6);
        inputActions.GamePlay.ChangeWeapon2.performed += ctx => Measure(6);
    }
    void Start()
    {

    }
    void Measure(int value)
    {
        if (value == numberOfKey&&touched)
        {
            tutorialScribe.GetComponent<Text>().text = null;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame

    void OnDrawGizmos()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        gameObject.GetComponent<BoxCollider>().size = colliderSize;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorialScribe.GetComponent<Text>().text = tutorialDialogue;
            touched = true;
        }
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
