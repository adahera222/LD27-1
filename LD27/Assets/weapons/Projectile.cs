using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed = 10;
    public Vector3 dir;
    public float lifespan = 3;
    float startTime;
    public void Start() {
        startTime = Time.time;
    }

    public void Update() {

        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Time.time - startTime > lifespan) {
            Destroy(gameObject);
        }
    }
}
