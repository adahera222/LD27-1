using UnityEngine;
using System.Collections;

public class CoolDown : MonoBehaviour {

    public Attack attack;
    public float startTime;
    public float timer;

    public void OnEnable() {
        startTime = Time.time;
    }
    
    public void OnDisable() {
        attack.enabled = true;
    }

	void Update () {
        if (Time.time - startTime > timer) {
            enabled = false;
        }
	}
}
