using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "New ElemntData", menuName = "Data/ElementData")]
public class ElementsData : ScriptablePersistentObject
{
    public Element[] elmtList;

    public void AddElmnt(GameObject newElmnt)
    {
        int _id = newElmnt.GetInstanceID();
        Element e = Array.Find(elmtList, elm => elm.id == _id);
        if (e != null)
        {
            return;
        }

        Element tmp = new Element();
        tmp.scnName = SceneManager.GetActiveScene().name;
        tmp.id = _id;
        tmp.active = newElmnt.activeSelf;

        Element[] elm = { tmp };
        if (elmtList.Length == 0)
        {
            elmtList = elm;
        }
        else
        {
            elmtList = elmtList.Concat(elm).ToArray();
        }
    }

    public void RefresData(GameObject newElmnt)
    {
        int _id = newElmnt.GetInstanceID();
        Element e = Array.Find(elmtList, elm => elm.id == _id);

        if(e != null)
        {
            e.active = newElmnt.activeSelf;
        }
    }

    public void RefresElemnt(GameObject elmnt)
    {
        int _id = elmnt.GetInstanceID();
        Element e = Array.Find(elmtList, elm => elm.id == _id);

        if (e != null)
        {
            elmnt.SetActive(e.active);
        }
        else
        {
            AddElmnt(elmnt);
        }
    }

    public override void ResetData()
    {
        
        Element[] emptyArray = new Element[0];
        elmtList = emptyArray;

        base.ResetData();
    }

    public int ElementCount()
    {
        if (elmtList.Length < 0) return 0;

        int counter = 0;
        for (int i = 0; i < elmtList.Length; i++)
        {
            if (elmtList[i] != null)
            {
                counter++;
            }
        }

        return counter;

    }
    public int ElementCount(bool activeCompare)
    {
        if(elmtList.Length < 0) return 0;

        int counter = 0;
        for(int i = 0; i < elmtList.Length; i++)
        {
            if(elmtList[i] != null)
            {
                if(elmtList[i].active == activeCompare)
                {
                    counter++;
                }
            }
        }

        return counter;

    }
}

[System.Serializable]
public class Element
{
    public string scnName;
    public int id;
    public bool active;
}
