using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public Lunge lunge;
    public Transform hero;

    public float rangeTrigger = 3;

	void Update () {
        if (Vector3.Distance(transform.position, hero.position) < rangeTrigger) {
            lunge.enabled = true;
            this.enabled = false;
        }
	}
}
