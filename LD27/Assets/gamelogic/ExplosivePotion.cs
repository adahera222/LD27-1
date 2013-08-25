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
        Explode();
    }

    public void Explode() {
        Collider[] things = Physics.OverlapSphere(transform.position, 100);
        
        foreach (Collider c in things) {
            AIControl ai = c.GetComponent<AIControl>();
            if (ai != null) {
                int num = Random.Range(0, 11);
                MeshFilter filter = ai.fctrl.CurrentFrame.GetComponentInChildren<MeshFilter>();
                Debug.Log(filter.mesh.name);
                for (int i = 0; i < num; i++) {
                    Vector3 p = GetRandomMeshSpacePos(filter);
                    Instantiate(gorePrefab, p, Quaternion.identity);
                }

                ai.hp = 0;
            }

            if (ai != null && ai.hp == 0 && !ai.dead) {
                ai.dead = true;
                ai.HandleDeath();
                return;
            }
        }
    }

    public Vector3 GetRandomMeshSpacePos(MeshFilter filter) {
        Vector3 vert = filter.mesh.vertices[Random.Range(0, filter.mesh.vertices.Length - 1)];
        Vector3 cent = filter.mesh.bounds.center;
        Vector3 randomPoint = Vector3.Lerp(vert, cent, Random.value);
        return transform.TransformPoint(randomPoint);
    }

   
}
