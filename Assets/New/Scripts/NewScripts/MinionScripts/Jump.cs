using UnityEngine;
public class Jump : MonoBehaviour
{
    public Rigidbody rigid;
    public float heightJump;
    public Transform groundCheck;
    [HideInInspector]
    public bool isGrounded, jumping;
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        groundCheck = transform.Find("GroundCheck");
    }

    public void Jumping(bool crouching, bool stunned)
    {
        if (isGrounded && !crouching && !stunned)
        {
            rigid.velocity = new Vector3(rigid.velocity.y, Mathf.Sqrt(0 - (2 * -9.8f * heightJump)));
            jumping = true;
        }
    }
    public void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, 1 << 3);
    }
}

