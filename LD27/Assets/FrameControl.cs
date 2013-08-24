using UnityEngine;
using System.Collections;

public class FrameControl : MonoBehaviour {

    public GameObject CurrentFrame {
        get {
            return currentFrame;
        }
    }

    GameObject currentFrame;

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
            Renderer r= t.GetComponentInChildren<Renderer>();
            if(r != null)
                r.enabled = false;
        }
    }
}
