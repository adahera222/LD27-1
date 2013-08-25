using UnityEngine;
using System.Collections;

public class MeshTimer: MonoBehaviour {

    public Game game;
    public TextMesh textMesh;
    public float countDown = 10;

    public void Update() { 
        textMesh.text = game.CountDown + "";
    }
}
