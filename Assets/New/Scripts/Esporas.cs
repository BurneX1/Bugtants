using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Esporas : MonoBehaviour
{
    public GameObject PLayer;
    public bool PlayerStay;

    public float Restante;
    public int TimeStay;
    public int MyTime;

    public Text Contador;

    // Start is called before the first frame update
    void Start()
    {
        PLayer = GameObject.FindGameObjectWithTag("Player");

        Restante = 1;
        TimeStay = MyTime;
        Contador.text = TimeStay.ToString();
    }
    private void Update()
    {
        if (!PlayerStay&&TimeStay!=MyTime)
        {
            Sumar();
        }
    }

    private void OnTriggerEnter(Collider cld)
    {
        if (cld.gameObject.tag == "Player")
        {
            PlayerStay = true;
        }
    }
    private void OnTriggerStay(Collider cld)
    {
        if (cld.gameObject.tag == "Player")
        {

            if (TimeStay >= 1)
            {
                Restar();
            }
            if (TimeStay == 0)
            {
                Debug.Log("Dead");
            }
        }
    }

    private void OnTriggerExit(Collider cld)
    {
        if (cld.gameObject.tag == "Player")
        {
            PlayerStay = false;
        }
    }

    void Restar()
    {
        Restante -= Time.deltaTime;
        if (Restante <= 0.001f)
        {
            TimeStay--;
            Restante = 1;
            Contador.text = TimeStay.ToString();
        }
    }
    void Sumar()
    {
        Restante -= Time.deltaTime;
        if (Restante <= 0.001f)
        {
            TimeStay++;
            Restante = 1;
            Contador.text = TimeStay.ToString();
        }
    }
}
