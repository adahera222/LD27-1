using UnityEngine;
using System.Collections;

public class Lunge : MonoBehaviour {

    public Vector3 lungeDir;
    public float speed;
    public SteeringBehavior steering;
    public SimpleLocomotion simpleLoc;
    public AIControl aicTRl;
    public BoxCollider bcol;
    public Pusher pusher;
    public float timer;
    public float startTime;

    public Transform body;

    bool warningCOmplete;

    public void OnEnable() {
        startTime = Time.time;
        steering.enabled = false;
        aicTRl.enabled = false;
        simpleLoc.enabled = false;
    }

    public void OnDisable() {
        steering.enabled = true;
        aicTRl.enabled = true;
        simpleLoc.enabled = true;
    }

    IEnumerator JumpArc() {

        yield break;
    }

	void Update () {
       
        transform.Translate(lungeDir.normalized * Time.deltaTime * speed);

        if (Time.time - startTime > timer) {
            enabled = false;
        }
	}

    public IEnumerator RiseAndFall(float duration) {
        float dt = 1 / duration;
        float x = 1;

        while (x < 1) {
            x += Time.deltaTime * dt;
            body.transform.position = new Vector3(1, x*0.5f, 1);
            yield return 1;
        }

        x = 1.0f;

        while (x > 0) {
            x -= Time.deltaTime * dt;
            body.transform.position = new Vector3(1, x*0.5f, 1);
            yield return 1;
        }
        x = 0;
        yield break;
    }
}
