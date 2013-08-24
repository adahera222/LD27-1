using UnityEngine;
using System.Collections;

public class FrameControl : MonoBehaviour {

    public GameObject currentFrame;

    void Awake() {
        Hide();
    }

    public void SetFrame(int frameid) {
        if(currentFrame!= null)
        currentFrame.GetComponentInChildren<Renderer>().enabled = false;
        currentFrame = GameObject.Find(name + "/" + frameid + "");
        currentFrame.GetComponentInChildren<Renderer>().enabled = true;
    }

    public void Hide() {
        foreach (Transform t in transform) {
            t.GetComponentInChildren<Renderer>().enabled = false;
        }
    }
}
