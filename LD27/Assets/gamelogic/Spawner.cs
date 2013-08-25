using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public static int TOTAL_ZEDS = 0;

    public GameObject zedPrefab;
    public float timer = 10;
    public float startTime;
	
	void Update () {
        if (Time.time - startTime > timer && TOTAL_ZEDS < 100) {
            TOTAL_ZEDS++;
            Instantiate(zedPrefab, transform.position, Quaternion.identity);
        }
	}
}
