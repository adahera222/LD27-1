using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {


    public bool blocked;

    public float speed;
    public Lunge lunge;
    public SteeringBehavior steering;
    public SimpleLocomotion simpleLoc;
    public AIControl aicTRl;
    public BoxCollider bcol;

    public Vector3 pushDir;

    public float timer;
    public float startTime;

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

        if (aicTRl.hp == 0 && !aicTRl.dead) {
            aicTRl.HandleDeath();
        }
    }

    public void Update() {
        transform.Translate(pushDir.normalized * Time.deltaTime * speed);

        if (Time.time - startTime > timer) {
            enabled = false;
        }
    }
}
