using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    private bool gameStarted = false;
    
    [SerializeField]
    private Text gameStateText;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private BirdMovement birdMovement;
    [SerializeField]
    private FollowCam followCam;
    private float restartDelay = 3f;
    private float restartTimer;
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        
        // removing the mouse cursor from the start of the game.
        Cursor.visible = true;

        // getting both ther player movement and health componants.
        playerMovement = player.GetComponent<PlayerMovement>();
        playerHealth = player.GetComponent<PlayerHealth>();

        // prevent the player and the bird from moving at the start of the game.
        playerMovement.enabled = false;
        birdMovement.enabled = false;

        // prevent the follow camera from zooming out before the game begins.
        followCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        // if the game has not started and the player presses the space bar then start the game.
        if (gameStarted == false && Input.GetKeyUp (KeyCode.Space)) {
            StartGame();
        }
        // if the player is no longer alive then end the game.
        if (playerHealth.alive == false) {

            //...the game has ended.
            EndGame();

            // increment a timeer to count up to restart.
            restartTimer = restartTimer + Time.deltaTime;

            // and if it reacjhes the restert delay...
            if (restartTimer >= restartDelay)
            {

                // then reload the current loaded level.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
	}
    private void StartGame () {

        // Set the game state and remove the start text.
        gameStarted = true;
        gameStateText.color = Color.clear;

        // Allow the player, bird and camera to move.
        playerMovement.enabled = true;
        birdMovement.enabled = true;
        followCam.enabled = true;
    }
    private void EndGame () {

        // Set thye game state to false.
        gameStarted = false;

        // show the game opver text.
        gameStateText.color = Color.white;
        gameStateText.text = "Game Over";

        // remove the player form the game.
        player.SetActive(false);
        
    }
}
