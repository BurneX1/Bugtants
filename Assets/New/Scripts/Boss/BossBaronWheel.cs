using UnityEngine;

public class BossBaronWheel : MonoBehaviour
{
    public EnemyLife[] suckersLife;
    public bool devourers;
    void Awake()
    {
        devourers = false;
    }

    void Update()
    {
        Conditional();
    }

    void Conditional()
    {
        foreach(EnemyLife suckers in suckersLife)
        {
            if (suckers.dead == true)
            {
                Destroy(gameObject);
            }
            else if (suckers.gameObject.GetComponent<EnemyAttract>().devouring == true)
            {
                devourers = true;
            }
        }

    }
}
