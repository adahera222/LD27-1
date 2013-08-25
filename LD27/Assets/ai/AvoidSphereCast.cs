using UnityEngine;
using System.Collections;

public class AvoidSphereCast : MonoBehaviour {

	 public float skinWidth = 0.1f;
    void Steer(SteerInfo info) {
        for (int i = 0; i < info.Count; ++i) {
            var d = transform.TransformDirection(info.Direction(i));
            var ray = new Ray(transform.position, d);
            RaycastHit hit;
			// Physics.SphereCast (ray, radius, out hitInfo, distance, layerMask);
            if (Physics.SphereCast(new Ray(transform.position,info.Direction(i)), transform.localScale.x,out hit,Mathf.Infinity)) {
                info.SetAvoid(i, 1 / (1+hit.distance - skinWidth));
            }
        }
    }
}
