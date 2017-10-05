using UnityEngine;
using System.Collections;

public class PickupParicalsDesrtruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // destory the "pickUp" prefab after 5 seconds
        Destroy(gameObject, 5f);
	}
}
