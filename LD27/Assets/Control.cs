using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
    
    public Transform body;
    public float x;
    public float z;
    public int facing;

    public float speed = 10.0f;

    public FrameControl fctrl;
    
    public void Update() {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        fctrl.SetFrame(Mathf.Abs(facing));
        if(Mathf.Abs(x) > 0 || Mathf.Abs(z)>0) UpdateFacing();

        transform.Translate(new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime));
    }

    public void UpdateFacing() {
        if (x == 0 && z == 1) {//north
            facing =  0;
        } else if (x == 0 && z == -1) {//south
            facing =  180;
        }else if (x == 1 && z == 0) {//east
            facing  = 90;
        }else if (x == -1 && z == 0) {//west
            facing =  270;
        }else if (x == -1 && z == 1) {//northwest
            facing = 315;
        }else if (x == -1 && z == -1) {//southwest
            facing = 225;
        }else if (x == 1 && z == -1) {//southeast
            facing = 135;
        }else if (x == 1 && z == 1) {//northeast
            facing = 45;
        }
    }
   
}
