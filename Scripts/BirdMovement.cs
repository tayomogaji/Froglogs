using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    [SerializeField]
    private Transform target;
    private NavMeshAgent birdAgent;
    private Animator birdAnimator;
    [SerializeField]
    private RandomSoundPlayer birdSteps;

	// Use this for initialization
	void Start () {
        birdAgent = GetComponent<NavMeshAgent>();
        birdAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        // set the bird destination
        birdAgent.SetDestination(target.position);
        
        // mesure the magnatude of the navMeshAagent volocity
        float speed = birdAgent.velocity.magnitude;

        // pass the volocity to the animator componant
        birdAnimator.SetFloat("Speed", speed);

        if (speed > 0f)
        {
            birdSteps.enabled = true;
        }
        else {
            birdSteps.enabled = false;
        }
    }
}
