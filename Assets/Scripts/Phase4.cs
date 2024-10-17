using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase4 : MonoBehaviour
{
    public Animator gate1;
    public Animator gate2;
    public Animator gate3;
    public Spider spider;
    public GameObject dialog;
    public Transform spawnPoint;
    public void OnTriggerEnter2D (Collider2D collider) {
        spider.shouldAttack = true;
        spider.shouldMove = true;
    }
    public void OnAll () {
        gate1.SetTrigger ("On");
        gate2.SetTrigger ("On");
        gate3.SetTrigger ("On");
    }
    public void OffAll () {
        gate1.SetTrigger ("Off");
        gate2.SetTrigger ("Off");
        gate3.SetTrigger ("Off");
    }
    public void Dialog () {
        spawnPoint.gameObject.SetActive (true);
        FindObjectOfType<AudioManager> ().Stop ("Coin");
		FindObjectOfType<AudioManager> ().Play ("Coin");
        GameObject.FindObjectOfType<GameManager> ().AddHonesty (15);
        GameObject.FindObjectOfType<GameManager> ().lastCheckPoint = spawnPoint.position;
        GameObject.FindObjectOfType<LaserWeapon> ().numberOfBulletes += Random.Range (10, 15);
        GameObject.FindObjectOfType<LaserWeapon> ().ammoTextUI.text = GameObject.FindObjectOfType<LaserWeapon> ().numberOfBulletes.ToString ();
        dialog.SetActive (true);
    }
}
