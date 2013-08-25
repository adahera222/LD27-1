using UnityEngine;
using System.Collections;

public class MeshTimer: MonoBehaviour {
    public TextMesh textMesh;
    public float countDown = 10;

    public void Update() { 
        countDown -= Time.deltaTime;
        float clamped = Mathf.Clamp(countDown, 0, 10);
        string val = countDown > -1 ? clamped.ToString("0") + "" : "$";
        textMesh.text = val;
    }
}
