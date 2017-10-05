using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Animator playerAnimator;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 movement;
    private float turningSpeed = 20f;
    private Rigidbody playerRigidbody;
    [SerializeField]
    private RandomSoundPlayer playerSteps;

	// Use this for initialization
	void Start () {

        //gathers componants from the player gameObject
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        // gathering imput from the keyboard
        moveHorizontal = Input.GetAxisRaw ("Horizontal");
        moveVertical = Input.GetAxisRaw ("Vertical");

        movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
	}

    void FixedUpdate() {
        // if the players movment vector does not equal zero...
        if (movement != Vector3.zero)
        {

            // ... SET A TARGET ROTATION based on the movement vector... 
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);

            // ... and CREATE A NEW ROTATION that moves from the current location to the targhet location...
            Quaternion newRotation = Quaternion.Lerp(playerRigidbody.rotation, targetRotation, Time.deltaTime * turningSpeed);

            // ... and CHANGE THE PLAYERS ROTATION to the new incremantal rotation..
            playerRigidbody.MoveRotation(newRotation);

            // ...then play the jump animation
            playerAnimator.SetFloat ("Speed", 3f);

            // play footstep sounds.
            playerSteps.enabled = true;
        }
        else {
            // otherwise dont play the jump animation
            playerAnimator.SetFloat ("Speed", 0f);

            // dont play footstep sounds.
            playerSteps.enabled = false;
        }
    }
}