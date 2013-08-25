using UnityEngine;
using System.Collections;

public class Attract : MonoBehaviour {

    public Transform target;

    public float strength = 1;

    void Steer(SteerInfo info) {
		
		if(target == null) return;
		
        for (int i = 0; i < info.Count; ++i) {
            var d = transform.TransformDirection(info.Direction(i));
            var diff = target.position - transform.position;
            var dot = Vector3.Dot(d, diff.normalized);
            var dist = diff.magnitude;
            info.SetSeek(i, Mathf.Clamp01(dot*strength * Mathf.Clamp01(dist / 5)));
        }
    }
}
