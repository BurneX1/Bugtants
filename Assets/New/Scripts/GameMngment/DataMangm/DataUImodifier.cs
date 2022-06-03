using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;

public class DataUImodifier : MonoBehaviour
{
    public ScriptablePersistentObject[] dataArray;

    public GameObject slidePref;
    public Transform contentParent;

    private void Awake()
    {
        UseParams(dataArray);
    }

    public FieldInfo[] GetParams(object obj)
    {
        Type theType = obj.GetType();
        FieldInfo[] fields = theType.GetFields();
        return fields;
    }
    public void UseParams(params object[] list)
    {
        
        for (int i = 0; i < list.Length; i++)
        {
            FieldInfo[] fieldArray = GetParams(list[i]);
            for (int e = 0; e < fieldArray.Length; e++)
            {
                if(fieldArray[e].FieldType == typeof(float))
                {
                    Debug.Log(fieldArray[e].Name);
                    GameObject tmp = Instantiate(slidePref, contentParent);
                    tmp.GetComponent<Text>().text = fieldArray[e].Name;
                }

            }
        }

    }

}
