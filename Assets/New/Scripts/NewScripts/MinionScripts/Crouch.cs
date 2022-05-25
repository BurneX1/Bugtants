using UnityEngine;

public class Crouch : MonoBehaviour
{
    [HideInInspector]
    public float height;
    [HideInInspector]
    public Vector3 centering;
    [HideInInspector]
    public bool crouching;
    private float timeCrouch = 0;

    private GameObject sight;
    private CrouchSeen see;
    private bool stuck;
    void Awake()
    {
        height=GetComponent<CapsuleCollider>().height;
        centering=GetComponent<CapsuleCollider>().center;
        sight = GameObject.Find("SeeCapsules/Head");
        see = sight.GetComponent<CrouchSeen>();
    }
    public void Crouching(float crouchChange)
    {
        if (!stuck)
        {
            if (timeCrouch >= crouchChange)
            {
                timeCrouch = crouchChange;
            }
            else
            {
                timeCrouch += Time.deltaTime;
            }
            height = 1.8f - timeCrouch * 2;
            centering = new Vector3(0, -timeCrouch, 0);
            sight.transform.localPosition = new Vector3(0, 0.9f - timeCrouch * 2, 0);
            crouching = true;
        }
    }
    public void NonCrouching(float crouchChange)
    {
        if (!stuck)
        {
            if (timeCrouch <= 0)
            {
                timeCrouch = 0;
            }
            else
            {
                timeCrouch -= Time.deltaTime;
            }
        }
        if (see.CrouchBool(crouchChange)) //Can get up
        {
            height = 1.8f - timeCrouch * 2;
            centering = new Vector3(0, -timeCrouch, 0);
            sight.transform.localPosition = new Vector3(0, 0.9f - timeCrouch * 2, 0);
            crouching = false;
            stuck = false;
        }
        else
        {
            height = 1.8f - crouchChange * 2;
            centering = new Vector3(0, -crouchChange, 0);
            sight.transform.localPosition = new Vector3(0, 0.9f - crouchChange * 2, 0);
            crouching = true;
            stuck = true;
        }
    }
}
