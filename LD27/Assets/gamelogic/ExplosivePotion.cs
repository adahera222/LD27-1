using UnityEngine;
using System.Collections;

public class ExplosivePotion : MonoBehaviour {

    public void Start() {
        Collider [] things = Physics.OverlapSphere(transform.position, 5);
        foreach (Collider c in things) { 
        
        }
    }

   
}
