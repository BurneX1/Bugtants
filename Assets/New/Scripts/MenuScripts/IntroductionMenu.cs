using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IntroductionMenu : MonoBehaviour
{
    public GameObject logoImage;
    public GameObject subtext;
    public float timer;

    // Start is called before the first frame update

    void Start()
    {
        logoImage.SetActive(false);
        subtext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 2f)
        {
            logoImage.SetActive(true);
            subtext.SetActive(true);
            timer = 0;
        }
    }
}
