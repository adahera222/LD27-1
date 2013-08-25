using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Game : MonoBehaviour {

    public HUD hud;
    float countDown = 10;
    public Control heroProtagonist;
    public Teleporter teleporterMesh;
    public GameObject currentTeleporter;

    public List<GameObject> modules = new List<GameObject>();

    public GameObject sparkerPrefab;

    public int CountDown {
        get {
            return Mathf.RoundToInt(countDown);
        }
    }



    public void Update() {
        hud.countDown = CountDown;
        countDown -= Time.deltaTime;
        float clamped = Mathf.Clamp(countDown, 0, 10);
        string val = countDown > -1 ? clamped.ToString("0") + "" : "--";

        if (val == "3") {
            SetClosestTeleporter();
            currentTeleporter.GetComponent<Module>().Locked();
            Time.timeScale = 0.5f;
        }

        if (val == "0" && ! teleporting) {
            teleporting = true;
            StartCoroutine(DoTeleport());
        }
    }
    bool teleporting;
    public IEnumerator DoTeleport() {
        Time.timeScale = 1.0f;
        yield return StartCoroutine(SparkOutEffect(0.2f));
        yield return StartCoroutine(ScaleOut(0.2f));
        Vector3 v = teleporterMesh.GetRandomMeshSpacePos();
        Vector3 cp = heroProtagonist.transform.position;
        heroProtagonist.transform.position = new Vector3(v.x, cp.y, v.z);
        currentTeleporter.GetComponent<Module>().Normal();
        SetClosestTeleporter();
        yield return StartCoroutine(SparkInEffect(0.3f));
        yield return StartCoroutine(ScaleIn(0.2f));
        ResetTimers();
        yield break;
    }

    public IEnumerator SparkOutEffect(float duration) {
        heroProtagonist.GetComponent<Control>().enabled = false;
        GameObject sp = (GameObject)Instantiate(sparkerPrefab, currentTeleporter.transform.position, Quaternion.identity);
        float dt = 1 / duration;
        float x = 0;
        Vector3 start = sp.transform.position;
        while(x < 1){
            sp.transform.position = Vector3.Lerp(start, heroProtagonist.transform.position,x);
            x += Time.deltaTime * dt;
            yield return null;
        }
        Destroy(sp);
        yield break;
    }


    public void SetClosestTeleporter() {
        currentTeleporter = modules.OrderByDescending(x => Vector3.Distance(x.transform.position, heroProtagonist.transform.position)).LastOrDefault();
    }

    public IEnumerator SparkInEffect(float duration) {
        GameObject sp = (GameObject)Instantiate(sparkerPrefab, currentTeleporter.transform.position, Quaternion.identity);
        float dt = 1 / duration;
        float x = 0;
        Vector3 start = sp.transform.position;
        while (x < 1) {
            sp.transform.position = Vector3.Lerp(start, heroProtagonist.transform.position, x);
            x += Time.deltaTime * dt;
            yield return null;
        }
        heroProtagonist.GetComponent<Control>().enabled = true;
        Destroy(sp);
        yield break;
    }

    public IEnumerator ScaleOut(float duration) {
        float dt = 1 / duration;
        float x = 1;

        while(x > 0){
            x -= Time.deltaTime * dt;
            heroProtagonist.body.transform.localScale = new Vector3(x,1,1);
            yield return 1;
        }

        yield break;
    }

    public IEnumerator ScaleIn(float duration) {
        float dt = 1 / duration;
        float x = 0;

        while (x < 1) {
            x += Time.deltaTime * dt;
            heroProtagonist.body.transform.localScale = new Vector3(x, 1, 1);
            yield return 1;
        }

        yield break;
    }
    
    public void HitTeleporter(GameObject hit) {
        if (currentTeleporter == hit) {
            ResetTimers();
            Time.timeScale = 1.0f;
        }
    }

    private void ResetTimers() {
        hud.countDown = 10;
        countDown = 10;
        teleporting = false;
    }
}
