using UnityEngine;
using System.Collections;

/**
 * dr critical
 */
public class Control : MonoBehaviour {
    
    public Transform body;
    public float x;
    public float z;
    public float facing;

    public float timeX = 0;
    public float timeZ = 0;
    public float timeY = 0;

    public float speed = 10;
    
    public void Update() {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
      

        body.localEulerAngles = new Vector3(0, facing, 0);
        if(Mathf.Abs(x) > 0 || Mathf.Abs(z)>0) UpdateFacing();

        if (Mathf.Abs(z) > 0) {
            timeZ += Time.deltaTime;
        }
        else {
            timeZ = 0;
        }
        if (Mathf.Abs(x) > 0) {
            timeX += Time.deltaTime;
        }
        else {
            timeX = 0;
        }

        TimedInputMove();
    }

    public void UpdateFacing() {
        if (x == 0 && Mathf.Sign(z) == 1) {//north
            facing =  0;
        } else if (x == 0 && Mathf.Sign(z) == -1) {//south
            facing =  -180;
        }else if (Mathf.Sign(x) == 1 && z == 0) {//east
            facing  = -270;
        }else if (Mathf.Sign(x) == -1 && z == 0) {//west
            facing =  -90;
        }
    }

    public void TimedInputMove() {

        if (timeX == timeZ && Mathf.Abs(timeX) > 0) {
            if (Random.Range(0, 100) > 50) {
                timeX += Time.deltaTime;
            }
            else {
                timeZ += Time.deltaTime;
            }
        }

        if (timeX > timeZ) {
            transform.Translate(new Vector3(Mathf.Sign(x) * speed * Time.deltaTime, 0, 0));
        } else if (timeZ > timeX) {
            transform.Translate(new Vector3(0, 0, Mathf.Sign(z) * speed * Time.deltaTime));
        }
    }
   
}
