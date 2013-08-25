﻿using UnityEngine;
using System.Collections;

public class Spark : MonoBehaviour {

    public float lifespan;
    float startTime;
    public void Start() {
        startTime = Time.time;
    }

    public void Update() {
        if (Time.time - startTime > lifespan) {
            Destroy(gameObject);
        }
    }
}
