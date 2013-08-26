using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Control : MonoBehaviour {


    public int life = 3;
    public List<GUITexture> lifebar = new List<GUITexture>();
    public int potions;
    public int skulls;

    public GUIText potionsVal;
    public GUIText skullsVal;
    public Game game;
    
    public GameObject potionsPrefab;
    public GameObject projectilePrefab;
    public Transform body;
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
        modes.Add(Mode3);
        modes.Add(Mode2);
        modes.Add(Mode1);
    }

    public void Start() {
        fctrl.SetFrame(0);
    }
   
    public void Update() {

        if (Input.GetMouseButtonUp(1) && potions != 0) {
            LaunchPoint[] launchPoints = fctrl.CurrentFrame.GetComponentsInChildren<LaunchPoint>();
            potions--;
            GameObject go = (GameObject)Instantiate(potionsPrefab, launchPoints[0].transform.position, Quaternion.identity);
            go.GetComponent<ExplosivePotion>().game = game;
        }

        if (Input.GetMouseButtonUp(0)) {
            LaunchPoint[] launchPoints = fctrl.CurrentFrame.GetComponentsInChildren<LaunchPoint>();
            foreach (LaunchPoint lp in launchPoints) {
                GameObject bullet = (GameObject)Instantiate(projectilePrefab,lp.transform.position,Quaternion.identity);
                bullet.GetComponent<Projectile>().dir = lp.transform.forward;
                bullet.GetComponent<Projectile>().friendly = name;
            }
        }

        if (Input.GetKeyUp(KeyCode.Alpha1)) {
            Mode1();
        }else if (Input.GetKeyUp(KeyCode.Alpha2)) {
            Mode2();
        } else if (Input.GetKeyUp(KeyCode.Alpha3)) {
            Mode3();
        }
        float mw = Input.GetAxisRaw("Mouse ScrollWheel");
        float smw = Mathf.Sign(mw);
        float curIndex = index;
        index +=  (Mathf.Abs(mw) > 0) ? Mathf.RoundToInt(1*smw) :  Mathf.RoundToInt(0*smw);
        
        if (index > modes.Count-1) index = modes.Count-1;
        if (index < 0) index = 0;
        if (curIndex != index) {
            modes[index]();
        }

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        fctrl.SetFrame(Mathf.Abs(facing));
        if(Mathf.Abs(x) > 0 || Mathf.Abs(z)>0) UpdateFacing();
        if (!Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            transform.Translate(new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime));

        potionsVal.text = "X " + potions;
        skullsVal.text = "X " + skulls;

        for (int i = 0; i < 4; i++) {
            lifebar[i].enabled = false;
        } 

        for (int i = 0; i < life; i++) {
            lifebar[i].enabled = true;
        }

        RaycastHit hit;
        if (Physics.SphereCast(new Ray(transform.position, transform.forward), 0.2f, out hit, 0.2f)) {
            if (hit.transform.name == "Zed") {
                Debug.Log("getting hit");
                life--;
                if (life < 0) {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void OnGUI() {
        if (life < 0) {
            if (GUILayout.Button("Play Again")) {
                Application.LoadLevel("main");
            }
        }
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

