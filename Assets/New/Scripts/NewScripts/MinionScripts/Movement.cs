using UnityEngine;
public class Movement : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody rigid;
    public float speed, spdBuff, gravity;
    [HideInInspector]
    public Vector2 direction;
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    public void Move(bool grounded)
    {
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
        float tmpSpd = speed * spdBuff;


        if (!grounded)
            rigid.velocity = new Vector3(tmpSpd * total.x, rigid.velocity.y, tmpSpd * total.z);
        if (grounded)
        {
            float graviton = rigid.velocity.y - gravity * Time.deltaTime;
            rigid.velocity = new Vector3(tmpSpd * total.x, graviton, tmpSpd * total.z);

        }

    }
    public void Quiet(bool grounded)
    {
        if (!grounded)
            rigid.velocity = new Vector3(0, rigid.velocity.y, 0);
        if (grounded)
        {
            float graviton = rigid.velocity.y - gravity * Time.deltaTime;
            rigid.velocity = new Vector3(0, graviton, 0);

        }

    }
}
