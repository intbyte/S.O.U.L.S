using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2 : MonoBehaviour
{
    public GameObject dialog1;
    public BulletSpawner canon1;
    public BulletSpawner canon2;
    public GameObject dialog2;
    public GameObject dialog3;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.tag == "Player") {
            canon1.enabled = true;
            canon2.enabled = true;
            dialog1.SetActive (true);
        }
    }
    public void PrisonBreak1 () {
        dialog2.SetActive (true);
    }
    public void PrisonBreak2 () {
        dialog3.SetActive (true);
    }
    public void GetReward () {
        spawnPoint.gameObject.SetActive (true);
        GameObject.FindObjectOfType<GameManager> ().AddHonesty (10);
        GameObject.FindObjectOfType<GameManager> ().lastCheckPoint = spawnPoint.position;
        FindObjectOfType<AudioManager> ().Stop ("Coin");
		FindObjectOfType<AudioManager> ().Play ("Coin");
        GameObject.FindObjectOfType<LaserWeapon> ().numberOfBulletes += Random.Range (10, 15);
        GameObject.FindObjectOfType<LaserWeapon> ().ammoTextUI.text = GameObject.FindObjectOfType<LaserWeapon> ().numberOfBulletes.ToString ();
    }
    public void GetReward2 () {
        spawnPoint2.gameObject.SetActive (true);
        GameObject.FindObjectOfType<GameManager> ().AddHonesty (7);
        GameObject.FindObjectOfType<GameManager> ().lastCheckPoint = spawnPoint2.position;
        FindObjectOfType<AudioManager> ().Stop ("Coin");
		FindObjectOfType<AudioManager> ().Play ("Coin");
        GameObject.FindObjectOfType<LaserWeapon> ().numberOfBulletes += Random.Range (10, 15);
        GameObject.FindObjectOfType<LaserWeapon> ().ammoTextUI.text = GameObject.FindObjectOfType<LaserWeapon> ().numberOfBulletes.ToString ();
    }
}
