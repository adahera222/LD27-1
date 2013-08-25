using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed = 10;
    public Vector3 dir;
    public float lifespan = 3;
    float startTime;
    public GameObject gore;

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

            AIControl ai = hit.transform.GetComponent<AIControl>();
            
            if (ai != null && ai.hp > 0) {
                ai.hp--;
                Pusher pusher = ai.transform.GetComponent<Pusher>();
                Lunge lunge = ai.transform.GetComponent<Lunge>();

                if (!lunge.enabled && !pusher.enabled) {
                    pusher.pushDir = dir;
                    pusher.enabled = true;
                }
                
                Instantiate(gore, hit.point, Quaternion.identity);
            }
            else if (ai != null && ai.hp < 0) {
                ai.HandleDeath();
            }
		}
    }
}
