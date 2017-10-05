using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSoundPlayer : MonoBehaviour {
  
    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> soundClip = new List<AudioClip>();

    [SerializeField]
    private float soundTimerDelay = 3f;
    private float soundTimer;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

        // increment a time to count up to restarting...
        soundTimer = soundTimer + Time.deltaTime;

        // if the sound timer reaches the delay...
        if (soundTimer >= soundTimerDelay ) {

            //...reset the timer.
            soundTimer = 0f;

            // choose a random sound...
            AudioClip randomSound = soundClip[Random.Range(0, soundClip.Count)];

            // and play the sound.
            audioSource.PlayOneShot(randomSound);
        }
	}
}
