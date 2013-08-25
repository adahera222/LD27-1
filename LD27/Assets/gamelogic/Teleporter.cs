using UnityEngine;
using System.Collections;


public class Teleporter : MonoBehaviour {

    public MeshFilter filter;
    public GameObject particlePrefab;

    public void Start() {
        filter = GetComponent<MeshFilter>();
    }

    public Vector3 GetRandomMeshSpacePos() {
        Vector3 vert = filter.mesh.vertices[Random.Range(0, filter.mesh.vertices.Length - 1)];
        Vector3 cent = filter.mesh.bounds.center;
        Vector3 randomPoint = Vector3.Lerp(vert, cent, Random.value);
        return transform.TransformPoint(randomPoint);
    }
}

