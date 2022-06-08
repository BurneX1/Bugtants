using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;

public class DataUImodifier : MonoBehaviour
{
    public ScriptablePersistentObject[] dataArray;

    public Transform contentParent;

    public GameObject slidePref;
    public GameObject inputNumPref;
    public GameObject inputStrPref;

   

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
    public void UseParams(ScriptablePersistentObject[] list)
    {
        
        for (int i = 0; i < list.Length; i++)
        {
            FieldInfo[] fieldArray = GetParams(list[i]);
            for (int e = 0; e < fieldArray.Length; e++)
            {
                if (fieldArray[e].FieldType == typeof(float))
                { 

                    if (fieldArray[e].GetCustomAttribute<RangeAttribute>() != null)
                    {
                        RangeAttribute range;
                        GameObject tmp = Instantiate(slidePref, contentParent);
                        Slider sld = tmp.GetComponent<Slider>();
                        sld.value = (float)fieldArray[e].GetValue(list[i]);

                        tmp.GetComponent<Text>().text = fieldArray[e].Name;

                        range = fieldArray[e].GetCustomAttribute<RangeAttribute>();
                        sld.minValue = range.min;
                        sld.maxValue = range.max;

                        int tmpE = e;
                        int tmpI = i;
                        sld.onValueChanged.AddListener(delegate
                        {
                            list[tmpI].SetVariable(fieldArray[tmpE].Name, sld.value);
                        });
                    }
                    else
                    {
                        GameObject tmp = Instantiate(inputNumPref, contentParent);
                        InputField inp = tmp.GetComponentInChildren<InputField>();
                        tmp.GetComponent<Text>().text = fieldArray[e].Name;
                        inp.text = fieldArray[e].GetValue(list[i]).ToString();


                        int tmpE = e;
                        int tmpI = i;
                        inp.onValueChanged.AddListener(delegate
                        {
                            list[tmpI].SetVariable(fieldArray[tmpE].Name, float.Parse(inp.text));
                        });
                    }

                }
                else if (fieldArray[e].FieldType == typeof(int))
                {
                    if (fieldArray[e].GetCustomAttribute<RangeAttribute>() != null)
                    {
                        RangeAttribute range;
                        GameObject tmp = Instantiate(slidePref, contentParent);
                        Slider sld = tmp.GetComponent<Slider>();
                        sld.value = (int)fieldArray[e].GetValue(list[i]);

                        tmp.GetComponent<Text>().text = fieldArray[e].Name;

                        range = fieldArray[e].GetCustomAttribute<RangeAttribute>();
                        sld.minValue = range.min;
                        sld.maxValue = range.max;

                        int tmpE = e;
                        int tmpI = i;
                        sld.onValueChanged.AddListener(delegate
                        {
                            int va = (int)sld.value;
                            list[tmpI].SetVariable(fieldArray[tmpE].Name, va);
                        });
                    }
                    else
                    {
                        GameObject tmp = Instantiate(inputNumPref, contentParent);
                        InputField inp = tmp.GetComponentInChildren<InputField>();
                        tmp.GetComponent<Text>().text = fieldArray[e].Name;
                        inp.text = fieldArray[e].GetValue(list[i]).ToString();


                        int tmpE = e;
                        int tmpI = i;
                        inp.onValueChanged.AddListener(delegate
                        {
                            int va = int.Parse(inp.text);
                            list[tmpI].SetVariable(fieldArray[tmpE].Name, va);
                        });
                    }
                }

            }
        }

    }

}
