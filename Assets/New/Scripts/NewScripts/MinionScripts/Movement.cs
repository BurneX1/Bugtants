using UnityEngine;
public class Movement : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody rigid;
    public float speed, spdBuff, gravity, slowRatio;
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public GameObject poseser;
    [HideInInspector]
    public bool grounded;

    public PlayerController playerCtrl;
    public PlayerData playerData;

    public bool antirun;
    public float antiruntimer, antirunMaxtimer;
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        playerCtrl = gameObject.GetComponent<PlayerController>();
        playerData = playerCtrl.playerData;
    }

    void Update()
    {
        AntirunCount();
    }

    public void Move()
    {
        rigid.useGravity = true;
        Vector3 right, forward, total;
        if (direction.x > 0.1f)
        {
            right = transform.right;
        }
        else if (direction.x < -0.1f)
        {
            right = -transform.right;
        }
        else
        {
            right = Vector3.zero;
        }
        if (direction.y > 0.1f)
        {
            forward = transform.forward;
        }
        else if (direction.y < -0.1f)
        {
            forward = -transform.forward;
        }
        else
        {
            forward = Vector3.zero;
        }
        total = Vector3.Normalize(right + forward);
        float tmpSpd = speed / slowRatio;


        if (!grounded)
        {
            float graviton = rigid.velocity.y - gravity * Time.deltaTime;
            rigid.velocity = new Vector3(tmpSpd * total.x, graviton, tmpSpd * total.z);
        }
        else if (grounded)
        {
            float graviton = rigid.velocity.y - gravity * Time.deltaTime;
            rigid.velocity = new Vector3(tmpSpd * total.x, graviton, tmpSpd * total.z);

        }

    }
    public void Quiet()
    {
        rigid.useGravity = true;
        if (!grounded)
        {
            float graviton = rigid.velocity.y - gravity * Time.deltaTime;
            rigid.velocity = new Vector3(0, graviton, 0);
        }
        else if (grounded)
        {
            float graviton = rigid.velocity.y - gravity * Time.deltaTime;
            rigid.velocity = new Vector3(0, graviton, 0);
        }

    }
    public void Posesed()
    {
        rigid.velocity = new Vector3(0, 0, 0);
        rigid.useGravity = false;
    }

    public void AntirunCount()
    {
        if(antirun == true)
        {
            antiruntimer += Time.deltaTime;
        }
    }



}
