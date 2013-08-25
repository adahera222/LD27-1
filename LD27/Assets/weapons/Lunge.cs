using UnityEngine;
using System.Collections;

public class Lunge : MonoBehaviour {

    public Transform hero;

    public Vector3 lungeDir;
    public float speed;
    public SteeringBehavior steering;
    public SimpleLocomotion simpleLoc;
    public AIControl aicTRl;
    public Attract attract;
    public BoxCollider bcol;
    public Attack attack;
    public Pusher pusher;
    public float timer;
    public float startTime;

    public Transform body;
    public CoolDown attackCoolDown;
    bool warningCOmplete;

    public void OnEnable() {
        lungeDir = (hero.transform.position - transform.position).normalized;
        startTime = Time.time;
        attract.enabled = false;
        steering.enabled = false;
        aicTRl.enabled = false;
        simpleLoc.enabled = false;
    }

    public void OnDisable() {
        steering.enabled = true;
        aicTRl.enabled = true;
        simpleLoc.enabled = true;
        attract.enabled = true;

        attackCoolDown.enabled = true;
    }

	void Update () {
        transform.Translate(lungeDir.normalized * Time.deltaTime * speed);

        if (Time.time - startTime > timer) {
            enabled = false;
        }
	}

   
}
