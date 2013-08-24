using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public float countDown = 10;

    public void Update() { 
        countDown -= Time.deltaTime;
        float clamped = Mathf.Clamp(countDown, 0, 10);
        string val = countDown > -1 ? clamped.ToString("0") + "" : "GAME OVER";
        guiText.text = val;
    }
}
