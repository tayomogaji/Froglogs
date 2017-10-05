using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {

    [SerializeField]
    private GameObject PickupPrefab;

    void OnTriggerEnter(Collider other) {
       
        // if the other collider is tagged with player, exicute fly pickup code by...
        if (other.CompareTag ("Player")) {

            // emmiting magical particals...
            Instantiate(PickupPrefab, transform.position, Quaternion.identity);

            // decerment the total number of flies

            FlySpawner.totalFies--;
            // up date the score
            ScoreCounter.score++;
            Destroy(gameObject);  
        }
    }
}
