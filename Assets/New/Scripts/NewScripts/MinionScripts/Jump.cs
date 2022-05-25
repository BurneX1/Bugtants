using UnityEngine;
public class Jump : MonoBehaviour
{
    public Rigidbody rigid;
    public float heightJump;
    public Transform groundCheck;
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        groundCheck = transform.Find("GroundCheck");
    }

    public void Jumping(bool crouching)
    {
        bool isGrounded;
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, 1 << 3);
        if (isGrounded && !crouching)
        rigid.velocity = new Vector3(rigid.velocity.y, Mathf.Sqrt(0 - (2 * -9.8f * heightJump)));
    }
}

