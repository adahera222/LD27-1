using UnityEngine;
using System.Collections;

public class Buoy : MonoBehaviour {
    public float radius;
    public void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
