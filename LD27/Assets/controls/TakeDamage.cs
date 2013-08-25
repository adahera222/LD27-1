using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

    public Vector3 pushDir;
    public float speed;
    public float timer;
    public float startTime;

    public void Update() {



        transform.Translate(pushDir.normalized * Time.deltaTime * speed);

        if (Time.time - startTime > timer) {
            enabled = false;
        }
    }
}
