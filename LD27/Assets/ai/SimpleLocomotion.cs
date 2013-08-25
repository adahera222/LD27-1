	using UnityEngine;
using System.Collections;

public class SimpleLocomotion : MonoBehaviour {
    public float speed = 5f;
    void Move(Vector3 dir) {
		Vector3 newPos = dir * Time.deltaTime * speed;
        transform.position += newPos;
    }
}
