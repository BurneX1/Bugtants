using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;
using UnityEditor;

[CreateAssetMenu(fileName = "New DataSaver", menuName = "Data/Save N Load Data")]
public class LoadNSaveData : ScriptableObject
{
    public ScriptablePersistentObject[] dataObj;


    public void SaveData()
    {
        if (dataObj.Length <= 0)
        {
            return;
        }
        for (int i = 0; i<dataObj.Length;i++)
        {
            if (dataObj[i] != null)
            {
                dataObj[i].Save();
            }

                

        }

    }

    public void LoadData()
    {
        if (dataObj.Length <= 0)
        {
            return;
        }
        for (int i = 0; i < dataObj.Length; i++)
        {
            if(dataObj[i]!=null)
            {
                dataObj[i].Load();
            }
                 
        }
    }

    public void Reset()
    {
        if(dataObj.Length<=0)
        {
            return;
        }
        for (int i = 0; i < dataObj.Length; i++)
        {
            if (dataObj[i] != null)
            {
                dataObj[i].ResetData();
            }

        }
    }
}

[CustomEditor(typeof(LoadNSaveData))]
class DataSaverEditor: Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LoadNSaveData dataSv = (LoadNSaveData)target;
        if (GUILayout.Button("Save"))
        {
            dataSv.SaveData();
        }
        if (GUILayout.Button("Load"))
        {
            dataSv.LoadData();
        }
        if (GUILayout.Button("Reset"))
        {
            dataSv.Reset();
        }
    }


}
