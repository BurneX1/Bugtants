using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    public enum Attributes { speed, gravity, jumpHeight };
    public InputField speedField, gravsField, jumpField;
    public PlayerMovement playerMoves;
    // Start is called before the first frame update
    void Start()
    {
        speedField.text = "" + playerMoves.speed;
        gravsField.text = "" + (playerMoves.gravity * -1);
        jumpField.text = "" + playerMoves.jumpHeight;
    }

    // Update is called once per frame
    void Update()
    {
        NumberChange();
    }
    void NumberChange()
    {
        int value;
        int.TryParse(speedField.text, out value);
        playerMoves.speed = value;
        int.TryParse(gravsField.text, out value);
        playerMoves.gravity = value;
        int.TryParse(jumpField.text, out value);
        playerMoves.jumpHeight = value;

    }
    /*public void SpeedModify(bool positive, Attributes att)
    {
        float count;
        if (positive)
        {
            count = 1;
        }
        else
        {
            count = -1;
        }
        if (att == Attributes.speed)
        {
            playerMoves.speed += count;
        }
    }*/
}
