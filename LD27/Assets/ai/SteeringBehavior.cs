using UnityEngine;
using System.Collections;
using System.Linq;

public class SteeringBehavior : MonoBehaviour {
    public int directionCount = 16;
    // Update is called once per frame
    void Update() {
        var info = new SteerInfo() {
            avoid = new float[directionCount],
            seek = new float[directionCount]
        };

        BroadcastMessage("Steer", info, SendMessageOptions.DontRequireReceiver);

        var dir = (
            from i in Enumerable.Range(0, directionCount)
            let s = info.seek[i]
            let a = 1 - info.avoid[i]
            let d = info.Direction(i)
            let v = Mathf.Min(a, s)
            where v > 0.001f
            orderby v descending
            select d * a)
            .FirstOrDefault();

        BroadcastMessage("Move", dir);
    }
}

public class SteerInfo {
    public float[] avoid;
    public float[] seek;

    public Vector3 Direction(int i) {
        var a = i / (float)Count * Mathf.PI * 2;
        var x = Mathf.Cos(a);
        var y = Mathf.Sin(a);
        return new Vector3(x, 0, y);
    }

    public void SetAvoid(int i, float value) {
        value = Mathf.Clamp01(value);
        avoid[i] = Mathf.Max(avoid[i], value);
    }

    public void SetSeek(int i, float value) {
        value = Mathf.Clamp01(value);
        seek[i] = Mathf.Max(seek[i], value);
    }
    public int Count {
        get { return avoid.Length; }
    }
}
