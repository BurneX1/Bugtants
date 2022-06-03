using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
public abstract class ScriptablePersistentObject : ScriptableObject
{

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
}
