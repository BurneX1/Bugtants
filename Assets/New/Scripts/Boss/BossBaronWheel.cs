using UnityEngine;

public class BossBaronWheel : MonoBehaviour
{
    public EnemyLife[] suckersLife;
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
        }

    }
}
