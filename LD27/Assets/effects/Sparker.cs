using UnityEngine;
using System.Collections;


public class Sparker : MonoBehaviour {

    public MeshFilter filter;
    public GameObject particlePrefab;
    public Light sparkLight;
    
    public void Update() {
        int num = Random.Range(0,11);
        for (int i = 0; i < num; i++) {
            sparkLight.intensity = Random.value * 2;
            GameObject go = (GameObject)Instantiate(particlePrefab, GetRandomMeshSpacePos(), Quaternion.identity);
        }
    }

    public Vector3 GetRandomMeshSpacePos() {
        Vector3 vert = filter.mesh.vertices[Random.Range(0, filter.mesh.vertices.Length - 1)];
        Vector3 cent = filter.mesh.bounds.center;
        Vector3 randomPoint = Vector3.Lerp(vert, cent, Random.value);
        return transform.TransformPoint(randomPoint);
    }
}
