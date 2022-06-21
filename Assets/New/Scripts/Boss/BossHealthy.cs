using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealthy : MonoBehaviour
{
    [Tooltip("La escena que manda luego de estar muerto")]
    public string sceneName;

    [Tooltip("Cuando el jefe lucha")]
    public bool activated;
    [Tooltip("Salud")]
    public float eyeHealth, tumoursHealth;
    [Tooltip("Tiempo de feedback")]
    public float damageFeedTimer, immuneFeedTimer;
    [Tooltip("Feedback de estados")]
    public Material isImmuneMat, damagedMat, immuneMat, deadMat;
    public GameObject tumoursDone, eyesDone;
    public Eye[] eyes, tumours;
    [Header("------------")]
    [Tooltip("Numero de ojos/tumores abiertos")]
    public int eyesOpen, tumoursOpen;

    [HideInInspector]
    public bool deadReset, dead;
    void Awake()
    {
        dead = false;
        activated = false;
        deadReset = false;
        foreach (Eye identifyEyes in eyes)
        {
            identifyEyes.eyeHealth = eyeHealth;
            identifyEyes.damageFeedTimer = damageFeedTimer;
            identifyEyes.immuneFeedTimer = immuneFeedTimer;
            identifyEyes.isImmuneMat = isImmuneMat;
            identifyEyes.damagedMat = damagedMat;
            identifyEyes.immuneMat = immuneMat; 
            identifyEyes.deadMat = deadMat;
            identifyEyes.ChangeEyes(true);
            identifyEyes.rage = false;
            identifyEyes.fatherEye = gameObject.GetComponent<BossHealthy>();
        }
        foreach (Eye identifyEyes in tumours)
        {
            identifyEyes.eyeHealth = eyeHealth;
            identifyEyes.damageFeedTimer = damageFeedTimer;
            identifyEyes.immuneFeedTimer = immuneFeedTimer;
            identifyEyes.isImmuneMat = isImmuneMat;
            identifyEyes.damagedMat = damagedMat;
            identifyEyes.immuneMat = immuneMat;
            identifyEyes.deadMat = deadMat;
            identifyEyes.ChangeEyes(true);
            identifyEyes.rage = true;
            identifyEyes.fatherEye = gameObject.GetComponent<BossHealthy>();
        }
        tumoursDone.SetActive(false);
    }

    public void Detect()
    {
        activated = true;
        CountEyes();
    }

    public void CountEyes()
    {
        int count = 0;
        if (eyes.Length != 0)
        {
            bool[] decretOpen = new bool[eyes.Length];
            if (eyes.Length >= eyesOpen)
            {
                while (count < eyesOpen)
                {
                    int choose = Random.Range(0, eyes.Length);
                    if (!decretOpen[choose])
                    {
                        decretOpen[choose] = true;
                        count++;
                    }
                }
                for (int i = 0; i < eyes.Length; i++)
                {
                    if (!decretOpen[i])
                    {
                        eyes[i].ChangeEyes(true);
                    }
                    else
                    {
                        eyes[i].ChangeEyes(false);
                    }
                }
            }
        }
        else if (tumours.Length != 0)
        {
            bool[] decretOpen = new bool[tumours.Length];
            if (tumours.Length >= tumoursOpen)
            {
                while (count < tumoursOpen)
                {
                    int choose = Random.Range(0, tumours.Length);
                    if (!decretOpen[choose])
                    {
                        decretOpen[choose] = true;
                        count++;
                    }
                }
                for (int i = 0; i < tumours.Length; i++)
                {
                    if (!decretOpen[i])
                    {
                        tumours[i].ChangeEyes(true);
                    }
                    else
                    {
                        tumours[i].ChangeEyes(false);
                    }
                }
            }
        }
        else
        {
            activated = false;
            dead = true;
        }
        if (deadReset)
            deadReset = false;
        if (dead)
        {
            StartCoroutine(OnVictory());
        }
    }
    public void DeadEye(bool rage)
    {
        deadReset = true;
        int deadCount = 0;
        if (!rage)
        {
            Eye[] actualeye = new Eye[eyes.Length - 1];
            for (int i = 0; i < eyes.Length; i++)
            {
                if (eyes[i].dead)
                {
                    deadCount++;
                }
                else
                {
                    actualeye[i - deadCount] = eyes[i];
                }
            }
            eyes = actualeye;
        }
        else
        {
            Eye[] actualeye = new Eye[tumours.Length - 1];
            for (int i = 0; i < tumours.Length; i++)
            {
                if (tumours[i].dead)
                {
                    deadCount++;
                }
                else
                {
                    actualeye[i - deadCount] = tumours[i];
                }
            }
            tumours = actualeye;
        }
        if (eyes.Length == 0 && !rage)
        {
            tumoursDone.SetActive(true);
            eyesDone.SetActive(false);
        }
        if (tumours.Length == 0 && rage)
        {
            tumoursDone.SetActive(false);
        }
        CountEyes();
    }
    IEnumerator OnVictory()
    {
        Debug.Log("Boss is dead");
        yield return new WaitForSeconds(40f);
        SceneManager.LoadScene(sceneName);

    }
}
