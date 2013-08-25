using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed = 10;
    public Vector3 dir;
    public float lifespan = 3;
    float startTime;

    public string friendly;

    public void Start() {
        startTime = Time.time;
    }

    public void Update() {
        float delta = Time.deltaTime*speed;
		transform.Translate(dir*delta);
		RaycastHit hit;
		if(Physics.Raycast(transform.position,-dir, out hit, delta) && hit.transform.name != friendly){
			Destroy(gameObject);
            if (hit.transform.name == "Zed") {
                Destroy(hit.transform.gameObject);
            }
		}
    }
}
