using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{

    public GameObject modifyObject;


    private float modifTime = 3;

    private Material mt;
    private float newExpVal;
    private Material mat;
    private int modify;
    private void Start()
    {
        mt = modifyObject.GetComponent<SkinnedMeshRenderer>().material;
        mat = new Material(mt);
        modifyObject.GetComponent<SkinnedMeshRenderer>().material = mat;
    }
    private void Update()
    {
        if (modify > 0)
        {
            LerpExpossure(newExpVal);
        }
    }
    private void LerpExpossure(float value)
    {
        float lerpVal = Mathf.Lerp(mat.GetFloat("_EmissiveExposureWeight"), value,modifTime*Time.deltaTime);

        mat.SetFloat("_EmissiveExposureWeight", lerpVal);
    }

    public void ExpossureChange(float value)
    {
        if (value >= 1) value = 1;
        if (value <= 0) value = 0;

        newExpVal = value;
        StartCoroutine(ActiveModifier(modifTime));

    }

    IEnumerator ActiveModifier(float time)
    {
        if(modify < 0)
        {
            modify = 0;
        }

        modify++;
        yield return new WaitForSeconds(time);
        modify--;

    }
}
