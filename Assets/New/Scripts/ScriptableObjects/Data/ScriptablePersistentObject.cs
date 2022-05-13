using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
