using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElementChecker : MonoBehaviour
{
    public ElementsData elmntList;
    public numPerEvent[] actionChecks;

    public void Start()
    {
        

    }
    public void DelayCheck(float delay)
    {
        StartCoroutine(DelayCheckCorr(delay));
    }
    public void Check()
    {
        int count = elmntList.ElementCount(false);
        for (int i = 0; i < actionChecks.Length; i++)
        {
            if(actionChecks[i].num <= count)
            {
               
                actionChecks[i].actions.Invoke();
            }
        }
    }

    public IEnumerator DelayCheckCorr(float delay)
    {
        yield return new WaitForSeconds(delay);
        Check();
    }
}

[System.Serializable]
public class numPerEvent
{
    public int num;
    public UnityEvent actions;
}
