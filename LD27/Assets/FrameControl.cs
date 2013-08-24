using UnityEngine;
using System.Collections;

public class FrameControl : MonoBehaviour {

    public GameObject currentFrame;

    void Awake() {
        GameObject g  = GameObject.Find("0");
        foreach (Transform t in transform) {
            t.GetComponentInChildren<Renderer>().enabled = false;
        }
        SetFrame(0);
    }

    public void SetFrame(int frameid) {
        if(currentFrame!= null)
        currentFrame.GetComponentInChildren<Renderer>().enabled = false;
        currentFrame = GameObject.Find(frameid + "");
        currentFrame.GetComponentInChildren<Renderer>().enabled = true;
    }
}
