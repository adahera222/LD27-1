using UnityEngine;
using System.Collections;

public class AIControl : MonoBehaviour {

    public float hp = 10;

    float x;
    float z;
    public int facing;
    public FrameControl fctrl;
    public Vector2 curDir;
    public GameObject deathPosePrefab;

    public bool dead;

    public Vector3 CurrentDirection {
        get {
            return curDir;
        }
    }

    public void Move(Vector3 dir) {
        curDir = dir;
        x = Mathf.Round(dir.x);
        z = Mathf.Round(dir.z);
    }

    void Start() {
        fctrl.SetRandomFrame();
    }

	void Update () {
        if (Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0) UpdateFacing();
        fctrl.SetFrame(Mathf.Abs(facing));
	}

    public void UpdateFacing() {
        if (x == 0 && z == 1) {
            facing = 0;
        }
        else if (x == 0 && z == -1) {
            facing = 180;
        }
        else if (x == 1 && z == 0) {
            facing = 90;
        }
        else if (x == -1 && z == 0) {
            facing = 270;
        }
        else if (x == -1 && z == 1) {
            facing = 315;
        }
        else if (x == -1 && z == -1) {
            facing = 225;
        }
        else if (x == 1 && z == -1) {
            facing = 135;
        }
        else if (x == 1 && z == 1) {
            facing = 45;
        }
    }

    public void HandleDeath() {
        Destroy(gameObject);
        GameObject go =  (GameObject)Instantiate(deathPosePrefab, transform.position, Quaternion.identity);
        go.GetComponent<DeathPose>().frameId = facing;
    }
}
