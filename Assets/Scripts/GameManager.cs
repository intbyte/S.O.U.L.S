using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject canon1;
    public GameObject canon2;
    public GameObject dialog1;
    public Vector2 lastCheckPoint;
    public GameObject player;
    public GameObject finishUI;
    public GameObject pauseUI;
    public GameObject timeoutUI;
    public Text clockUI;
    public Slider honestySlider;
    public List<string> stratup;
    public Sprite instructor;
    public InstructionManager inMan;
    
    public PlayerMovement comp1;
    public LaserWeapon comp2;

    public int honesty = 0;

    bool paused = false;
    void Start () {
        StartCoroutine (Countdown ());
        FindObjectOfType<AudioManager> ().StopAll ();
		FindObjectOfType<AudioManager> ().Play ("Gameplay");
        StartCoroutine (Wait ());
    }
    IEnumerator Wait () {
        yield return new WaitForSeconds (2f);
        inMan.ShowInstruction (stratup, instructor);
    }
    IEnumerator Countdown () {
        int s = 600;
        for (; s > -1;) {
            yield return new WaitForSeconds (1f);
            if (paused)
                continue;
            s--;
            int min = s / 60;
            int second = s % 60;
            clockUI.text = min.ToString () + ":" + second.ToString ();
        }
    }

    public void AddHonesty (int value) {
        honesty += value;
        if (honesty > 100)
            honesty = 100;
        honestySlider.value = honesty;
    }
    public void RemoveHonesty (int value) {
        honesty -= value;
        honestySlider.value = honesty;
    }
    public void TrunOnCanons1() {
        canon1.GetComponent<BulletSpawner> ().enabled = true;
        canon2.GetComponent<BulletSpawner> ().enabled = true;
    }
    public void TrunOffCanons1() {
        canon1.GetComponent<BulletSpawner> ().enabled = false;
        canon2.GetComponent<BulletSpawner> ().enabled = false;
    }
    public void TurnOnDialog1 () {
        AddHonesty (5);
        GameObject.FindObjectOfType<LaserWeapon> ().numberOfBulletes += 5;
        StartCoroutine (Wait (1f));
        dialog1.SetActive (true);
    }
    IEnumerator Wait (float seconds) {
        yield return new WaitForSeconds (seconds);
    }
    public void TimeOut () {
        StopAll ();
        timeoutUI.SetActive (true);
    }
    public void GameOver () {
        FindObjectOfType<AudioManager> ().Stop ("Revive");
		FindObjectOfType<AudioManager> ().Play ("Revive");
        player.transform.position = lastCheckPoint;
        player.GetComponent<PlayerHealth> ().health = 100;
        player.GetComponent<PlayerHealth> ().alive = true;
        player.GetComponent<PlayerHealth> ().healthSlider.value = 100;
    }
    public void Finish () {
        StopAllCoroutines ();
        Debug.Log ("Game End");
        StopAll ();
        finishUI.SetActive (true);
    }
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            StopAll ();
            pauseUI.SetActive (true);
            paused = true;
        }
    }
    public void StopAll () {
        EnemyController cont = GameObject.FindObjectOfType<EnemyController> ();
        if (cont != null)
            cont.enabled = false;
        Spider[] arr = GameObject.FindObjectsOfType<Spider> ();
        for (int i = 0; i < arr.Length; i++)
            arr[i].enabled = false;
        Bullet[] ar = GameObject.FindObjectsOfType<Bullet> ();
        for (int i = 0; i < ar.Length; i++)
            ar[i].enabled = false;
        BulletSpawner[] arrr = GameObject.FindObjectsOfType<BulletSpawner> ();
        for (int i = 0; i < arrr.Length; i++)
            arrr[i].enabled = false;
        comp1.enabled = false;
        comp2.enabled = false;
    }
    public void StartAll () {
        EnemyController cont = GameObject.FindObjectOfType<EnemyController> ();
        if (cont != null)
            cont.enabled = true;
        Spider[] arr = GameObject.FindObjectsOfType<Spider> ();
        for (int i = 0; i < arr.Length; i++)
            arr[i].enabled = true;
            Bullet[] ar = GameObject.FindObjectsOfType<Bullet> ();
        for (int i = 0; i < ar.Length; i++)
            ar[i].enabled = true;
        BulletSpawner[] arrr = GameObject.FindObjectsOfType<BulletSpawner> ();
        for (int i = 0; i < arrr.Length; i++)
            arrr[i].enabled = true;
        comp1.enabled = true;
        comp2.enabled = true;
    }
    public void Resume () {
        pauseUI.SetActive (false);
        paused = false;
        StartAll ();
    }
}
