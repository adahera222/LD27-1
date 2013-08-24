using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Control : MonoBehaviour {


    public List<FrameControl> frameSets = new List<FrameControl>();
    List<Action> modes = new List<Action>();
    public int mode;
    public float x;
    public float z;
    public int facing;

    public float speed = 10.0f;
    public int index = 0;
    public FrameControl fctrl;

    public void Awake() {
        modes.Add(Mode1);
        modes.Add(Mode2);
        modes.Add(Mode3);
    }

    public void Start() {
        fctrl.SetFrame(0);
    }
   
    public void Update() {

        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            Mode1();
        }else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Mode2();
        } else if (Input.GetKeyUp(KeyCode.Alpha3)) {
            Mode3();
        }
        float mw = Input.GetAxisRaw("Mouse ScrollWheel");
        float smw = Mathf.Sign(mw);
        index +=  (Mathf.Abs(mw) > 0) ? Mathf.RoundToInt(1*smw) :  Mathf.RoundToInt(0*smw);
        if (index > modes.Count-1) index = modes.Count-1;
        if (index < 0) index = 0;
        modes[index]();

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        fctrl.SetFrame(Mathf.Abs(facing));
        if(Mathf.Abs(x) > 0 || Mathf.Abs(z)>0) UpdateFacing();
        transform.Translate(new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime));
    }

    public void Mode1() {
        fctrl.Hide();
        fctrl = frameSets[0];
        fctrl.SetFrame(facing);
    }

    public void Mode2() {
        fctrl.Hide();
        fctrl = frameSets[1];
        fctrl.SetFrame(facing);
    }

    public void Mode3() {
        fctrl.Hide();
        fctrl = frameSets[2];
        fctrl.SetFrame(facing);
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

