using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Animaters : MonoBehaviour
{
    public UnityEvent animationPoint;
    public void Playing()
    {
        animationPoint.Invoke();
    }
}
