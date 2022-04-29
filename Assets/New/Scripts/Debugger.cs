using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    public GameObject[] parts;
    public InputField speedField, gravsField, jumpField, shootrtField, bulletspdField, crouchField, runField, crouchSpdField;
    private PlayerMovement playerMoves;
    private ShootPlayer shootPlayer;
    // Start is called before the first frame update
    void Start()
    {
        playerMoves = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        shootPlayer = GameObject.FindGameObjectWithTag("PlayerShoot").GetComponent<ShootPlayer>();
        speedField.text = "" + playerMoves.saveSpeed;
        gravsField.text = "" + (playerMoves.gravity * -1);
        jumpField.text = "" + playerMoves.jumpHeight;
        shootrtField.text = "" + shootPlayer.maxTimer;
        bulletspdField.text = "" + shootPlayer.bulletSpeed;
        crouchField.text = "" + playerMoves.crouchChange;
        runField.text = "" + playerMoves.multiplierSpeed;
        crouchSpdField.text = "" + playerMoves.dividerSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        NumberChange();
    }
    void NumberChange()
    {
        float value;
        float.TryParse(speedField.text, out value);
        playerMoves.saveSpeed = value;
        float.TryParse(gravsField.text, out value);
        playerMoves.gravity = value*-1;
        float.TryParse(jumpField.text, out value);
        playerMoves.jumpHeight = value;
        float.TryParse(shootrtField.text, out value);
        shootPlayer.maxTimer = value;
        float.TryParse(bulletspdField.text, out value);
        shootPlayer.bulletSpeed = value;
        float.TryParse(crouchField.text, out value);
        playerMoves.crouchChange = value;
        float.TryParse(runField.text, out value);
        playerMoves.multiplierSpeed = value;
        float.TryParse(crouchSpdField.text, out value);
        playerMoves.dividerSpeed = value;

    }

}
