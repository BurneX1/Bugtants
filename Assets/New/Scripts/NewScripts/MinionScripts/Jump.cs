using UnityEngine;
public class Jump : MonoBehaviour
{
    public Rigidbody rigid;
    public float heightJump, direction;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }
    /*void Start()
    {
        Jumping();
    }*/
    public void Jumping()
    {
        rigid.velocity = new Vector3(rigid.velocity.y, Mathf.Sqrt(0 - (2 * -9.8f * heightJump)));
    }
}

