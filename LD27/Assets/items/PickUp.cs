using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public AudioSource source;

    public void Update() {
       
       RaycastHit[] hits = Physics.RaycastAll(transform.position, -transform.forward, 0.3f);
        foreach(var hit in hits){
            if (hit.transform.name == "Control") {
                Control ctrl = hit.transform.GetComponent<Control>();
                if (ctrl != null && name == "medkit" && ctrl.life < 3) {
                    ctrl.life++;
                    if (ctrl.life > 3) {
                        ctrl.life = 3;
                    }
                    Destroy(gameObject);
                    return;
                }

                if (ctrl != null && name == "skull") {
                    ctrl.skulls++;
                    Destroy(gameObject);
                    return;
                }
               
            }
        }
    }
}
