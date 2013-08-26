using UnityEngine;
using System.Collections;

public class DeathPose : MonoBehaviour {

    public int frameId = 0;
    public FrameControl ctrl;
    public float timer;
    public float startTime;
    public GameObject skullItemPrefab;

    bool fadeStarted = false;
    public void OnEnable() {
        timer = Time.time;
        ctrl.SetFrame(frameId);
    }

    public void Update() {
        if (Time.time - startTime > timer && !fadeStarted) {
            fadeStarted = true;
            StartCoroutine(FadeOut(2.0f));
        }
    }

    IEnumerator FadeOut(float time) {
        float rate = 1.0f / time;
        float t = 1;
        Renderer r = ctrl.CurrentFrame.transform.GetComponentInChildren<Renderer>();
        while (t > 0) {
            t -= Time.deltaTime * rate;
            Color c = r.material.color;
            r.material.color = new Color(c.r, c.g, c.b, t);
            yield return null;
        }
        r.material.color = new Color(0, 0, 0, 0);

        float num = Random.Range(0, 10);

        if (num < 6) {
           GameObject go = (GameObject) Instantiate(skullItemPrefab, transform.position, Quaternion.identity);
           go.name = "skull";
        }

        Destroy(gameObject);
        yield break;
    }
}
