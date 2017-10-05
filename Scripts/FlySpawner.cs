using UnityEngine;
using System.Collections;

public class FlySpawner : MonoBehaviour {

    [SerializeField]
    private GameObject flyPrefab;
    [SerializeField]
    private int flyMinimum = 12;
    
    private float spawArea = 25;

    public static int totalFies;

	// Use this for initialization
	void Start () {
        totalFies = 0;
	}
	
	// Update is called once per frame
	void Update () {

        // while the totaql number of flies is less than the minium...
        while (totalFies < flyMinimum) {

            // then increment the totle number of flies....
            totalFies++;

            // then create a new position for a fly...
            float positionX = Random.Range(-spawArea, spawArea);
            float positionZ = Random.Range(-spawArea, spawArea);

            Vector3 flyPositon = new Vector3(positionX, 2f, positionZ);

            // and create a new fly.
            Instantiate(flyPrefab, flyPositon, Quaternion.identity);
        } 
	}
}
