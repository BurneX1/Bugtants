using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System;
public abstract class ScriptablePersistentObject : ScriptableObject
{
    public event Action Refresh = delegate { };
    //Path: Application.dataPath + "/Settings/Data/" + this.name + "Data.json"
    public virtual void Save()
    {
        string tmpJson = JsonConvert.SerializeObject(this);
        Debug.Log(tmpJson);
        Debug.Log(Application.dataPath + "/Settings/Data/" + this.name + "Data.json");
        File.WriteAllText(Application.dataPath + "/Settings/Data/" + this.name + "Data.json", tmpJson);
    }
    public virtual void Load()
    {

        JsonUtility.FromJsonOverwrite(File.ReadAllText(Application.dataPath + "/Settings/Data/" + this.name + "Data.json"), this);


    }

    public virtual void ResetData()
    {
        //Save();
    }
    public virtual void SetVariable(string fieldName, int value)
    {

        Type theType = this.GetType();
        FieldInfo field = theType.GetField(fieldName);

        if (field.FieldType == null)
        {
            Debug.LogWarning("The field " + fieldName + " was not found in " + this + " script");
            return;
        }

        if (field.FieldType != value.GetType())
        {
            Debug.LogWarning("The field " + fieldName + " is not the same type as the value   " + field.FieldType + "  ! " + value.GetType());
            return;
        }

        field.SetValue(this, value);
        Refresh.Invoke();
    }
    public virtual void SetVariable(string fieldName, float value)
    {

        Type theType = this.GetType();
        FieldInfo field = theType.GetField(fieldName);

        if(field.FieldType == null)
        {
            Debug.LogWarning("The field " + fieldName + " was not found in " + this + " script");
            return;
        }

        if(field.FieldType != value.GetType())
        {
            Debug.LogWarning("The field " + fieldName + " is not the same type as the value   " + field.FieldType + "  ! " + value.GetType());
            return;
        }

        field.SetValue(this, value);
        Refresh.Invoke();
    }
    public virtual void SetVariable(string fieldName, string value)
    {

        Type theType = this.GetType();
        FieldInfo field = theType.GetField(fieldName);

        if (field.FieldType == null)
        {
            Debug.LogWarning("The field " + fieldName + " was not found in " + this + " script");
            return;
        }

        if (field.FieldType != value.GetType())
        {
            Debug.LogWarning("The field " + fieldName + " is not the same type as the value   " + field.FieldType + "  ! " + value.GetType());
            return;
        }

        field.SetValue(this, value);
        Refresh.Invoke();
    }
    public virtual void SetVariable(string fieldName, bool value)
    {

        Type theType = this.GetType();
        FieldInfo field = theType.GetField(fieldName);

        if (field.FieldType == null)
        {
            Debug.LogWarning("The field " + fieldName + " was not found in " + this + " script");
            return;
        }

        if (field.FieldType != value.GetType())
        {
            Debug.LogWarning("The field " + fieldName + " is not the same type as the value   " + field.FieldType + "  ! " + value.GetType());
            return;
        }

        field.SetValue(this, value);
        Refresh.Invoke();
    }
}
