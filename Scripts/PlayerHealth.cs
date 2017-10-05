using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    private GameObject PickUpPrefab;
    public bool alive;

	// Use this for initialization
	void Start () {
        alive = true;
	
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy") && alive == true) {
            alive = false;
            // create tyhr pickup particals
            Instantiate(PickUpPrefab, transform.position, Quaternion.identity);
        }
    }
}
