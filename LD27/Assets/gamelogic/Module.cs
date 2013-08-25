using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour {
    public Game game;

    public void CancelTeleport() {
        game.ResetCounter();
    }
}
