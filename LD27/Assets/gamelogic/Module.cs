using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour {
    public Game game;
    public GameObject normal;
    public GameObject locked;
    public Light light;

    public void Start() {
        Normal();
    }

    public void TryCancelTeleport() {
        game.HitTeleporter(this.gameObject);
        Normal();
    }

    public void Locked() {
        light.enabled = true;
        normal.GetComponentInChildren<Renderer>().enabled = false;
        locked.GetComponentInChildren<Renderer>().enabled = true;
    }

    public void Normal() {
        light.enabled = false;
        normal.GetComponentInChildren<Renderer>().enabled = true;
        locked.GetComponentInChildren<Renderer>().enabled = false;
    }
}
