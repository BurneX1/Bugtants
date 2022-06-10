using UnityEngine;

public class BossEyes : MonoBehaviour
{
    [Tooltip("Salud")]
    public float eyeHealth;
    [Tooltip("Tiempo de feedback")]
    public float damageFeedTimer, immuneFeedTimer;
    [Tooltip("Feedback de estados")]
    public Material isImmuneMat, damagedMat, immuneMat, deadMat;
    public Eye[] eyes;
    [Header("------------")]
    [Tooltip("Numero de ojos abiertos")]
    public int eyesOpen;

    [HideInInspector]
    public bool deadReset;
    void Awake()
    {
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
            identifyEyes.fatherEye = gameObject.GetComponent<BossEyes>();
        }
        Detect();
    }

    public void Detect()
    {
        CountEyes();
    }

    public void CountEyes()
    {
        int count=0;
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
            if (deadReset)
                deadReset = false;
        }

    }
    public void DeadEye()
    {
        deadReset = true;
        int deadCount = 0;
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
        CountEyes();
    }
}
