using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
class DataSaverEditor : Editor
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
