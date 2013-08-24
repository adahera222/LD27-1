using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {


    public List<FrameControl> frameSets = new List<FrameControl>();

    public int mode;
    public float x;
    public float z;
    public int facing;

    public float speed = 10.0f;

    public FrameControl fctrl;

    public void Start() {
        fctrl.SetFrame(0);
    }

    public void Update() {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        fctrl.SetFrame(Mathf.Abs(facing));
        if(Mathf.Abs(x) > 0 || Mathf.Abs(z)>0) UpdateFacing();
        transform.Translate(new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime));

        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            Debug.Log("1");
            fctrl.Hide();
            fctrl = frameSets[0];
            fctrl.SetFrame(facing);
        }else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Debug.Log("2");
            fctrl.Hide();
            fctrl = frameSets[1];
            fctrl.SetFrame(facing);
        }else if (Input.GetKeyUp(KeyCode.Alpha3)) {
            Debug.Log("3");
            fctrl.Hide();
            fctrl = frameSets[2];
            fctrl.SetFrame(facing);
        }
    }

    public void UpdateFacing() {
        if (x == 0 && z == 1) {
            facing =  0;
        } else if (x == 0 && z == -1) {
            facing =  180;
        }else if (x == 1 && z == 0) {
            facing  = 90;
        }else if (x == -1 && z == 0) {
            facing =  270;
        }else if (x == -1 && z == 1) {
            facing = 315;
        }else if (x == -1 && z == -1) {
            facing = 225;
        }else if (x == 1 && z == -1) {
            facing = 135;
        }else if (x == 1 && z == 1) {
            facing = 45;
        }
    }
   
}

