using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public abstract class ScriptablePersistentObject : ScriptableObject
{

    //Path: Application.dataPath + "/Settings/Data/" + this.name + "Data.json"
    public virtual void Save()
    {
        
    }
        
    public virtual void Load()
    {

    }
}
