using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public HUD hud;
    float countDown = 10;
    public Control heroProtagonist;
    public Teleporter teleporter;

    public void Update() {
        countDown -= Time.deltaTime;
        float clamped = Mathf.Clamp(countDown, 0, 10);
        string val = countDown > -1 ? clamped.ToString("0") + "" : "--";

        if (val == "3") {
            Time.timeScale = 0.5f;
        }

        if (val == "0") {
            Vector3 v = teleporter.GetRandomMeshSpacePos();
            Vector3 cp = heroProtagonist.transform.position;
            heroProtagonist.transform.position = new Vector3(v.x,cp.y,v.z);
            hud.countDown = 10;
            countDown = 10;
            Time.timeScale = 1.0f;
        }
    }
}
