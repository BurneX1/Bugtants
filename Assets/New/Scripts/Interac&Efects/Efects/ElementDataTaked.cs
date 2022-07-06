using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementDataTaked : MonoBehaviour
{
    public ElementsData elmntList;
    public bool taked = false;

    public void Take(bool take)
    {
        taked = take;
    }
    private void Awake()
    {


    }

    private void OnEnable()
    {
        elmntList.RefresElemnt(gameObject);
    }



    private void OnDisable()
    {
        if (taked == true)
        {
            elmntList.RefresData(gameObject);
        }

    }
}
