using UnityEngine;
public class Jump : MonoBehaviour
{
    public Rigidbody rigid;
    public float heightJump;
    public Transform groundCheck;
    public bool isGrounded;
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        groundCheck = transform.Find("GroundCheck");
    }

    public void Jumping(bool crouching, bool stunned)
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.01f, 1 << 3);
        if (isGrounded && !crouching && !stunned)
        rigid.velocity = new Vector3(rigid.velocity.y, Mathf.Sqrt(0 - (2 * -9.8f * heightJump)));
    }
}

