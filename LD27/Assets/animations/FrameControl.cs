using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FrameControl : MonoBehaviour {

    public static List<int> frameIds = new List<int>(new int[]{0,45,90,135,180,225,270,315});

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
        foreach (Transform child in transform) {
            if (child.name == frameid+"") {
                currentFrame = child.gameObject;
            }
        }
        currentFrame.GetComponentInChildren<Renderer>().enabled = true;
    }

    public void SetRandomFrame() {
        SetFrame(frameIds[Random.Range(0, 7)]);
    }

    public void Hide() {
        foreach (Transform t in transform) {
            Renderer r= t.GetComponentInChildren<Renderer>();
            if(r != null)
                r.enabled = false;
        }
    }
}
