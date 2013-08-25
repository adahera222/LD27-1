using UnityEngine;
using System.Collections;

public class AvoidSphereCast : MonoBehaviour {

	 public float skinWidth = 0.1f;
    public void Steer(SteerInfo info) {
        for (int i = 0; i < info.Count; ++i) {
            var d = transform.TransformDirection(info.Direction(i));
            var ray = new Ray(transform.position, d);
            RaycastHit hit;
            if (Physics.SphereCast(new Ray(transform.position,info.Direction(i)), 0.1f,out hit,Mathf.Infinity)) {
                info.SetAvoid(i, 1 / (1+hit.distance - skinWidth));
            }
        }
    }
}
