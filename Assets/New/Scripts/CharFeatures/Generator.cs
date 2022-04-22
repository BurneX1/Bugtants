using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public GenObject[] objArray;


    public void Generate()
    {
        for(int i = 0; i < objArray.Length; i++)
        {
            for (int e = 0; e < objArray[i].amount; e++)
            {
                //Instanciar Elemento (Recomendacion, volver a actualizar en el furuto e implementar un Generation Managers)
                GameObject.Instantiate(
                    objArray[i].obj, 
                    new Vector3
                    (gameObject.transform.position.x + Random.Range(objArray[i].disperse * -1, objArray[i].disperse), 
                    gameObject.transform.position.y + Random.Range(0, objArray[i].disperse), 
                    gameObject.transform.position.z + Random.Range(objArray[i].disperse * -1, objArray[i].disperse) ) , 
                    gameObject.transform.rotation);
            }
        }
    }

}


[System.Serializable]
public class GenObject
{
    
    public GameObject obj;
    public int amount;
    public float disperse;

}
