using UnityEngine;
using System.Collections;

public class ExplosivePotion : MonoBehaviour {

    public GameObject gorePrefab;
    public Game game;
    
    public void Start() {
        StartCoroutine(WaitThenExplode());
    }

    public IEnumerator WaitThenExplode() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

  

    public Vector3 GetRandomMeshSpacePos(MeshFilter filter) {
        Vector3 vert = filter.mesh.vertices[Random.Range(0, filter.mesh.vertices.Length - 1)];
        Vector3 cent = filter.mesh.bounds.center;
        Vector3 randomPoint = Vector3.Lerp(vert, cent, Random.value);
        return transform.TransformPoint(randomPoint);
    }

   
}
