using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed, spdBuff;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    /*public void Update()
    {
        Move();
    }*/
    public void Move(Vector2 direction)
    {
        float tmpSpd = speed + spdBuff;
        rigid.velocity = new Vector3(tmpSpd * direction.x, rigid.velocity.y, tmpSpd * direction.y);
    }
}
