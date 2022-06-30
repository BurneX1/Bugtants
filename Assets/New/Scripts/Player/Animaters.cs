using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaters : MonoBehaviour
{
    private PlayerController playerControl;
    void Awake()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void Playing()
    {

    }
}
