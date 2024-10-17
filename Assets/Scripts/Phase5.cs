using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase5 : MonoBehaviour
{
    public GameObject enemyTypeOne;
    public Spider spider;
    public BulletSpawner canon1, canon2;
    public Torch one, two, three, four;
    public Animator gate;
    public GameObject dialog;
    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Player") {
            enemyTypeOne.SetActive (true);
            spider.shouldMove = true;
            spider.shouldAttack = true;
            canon1.enabled = true;
            canon2.enabled = true;
        }
    }
    public void UpdateGate () {
        if (one && two && three && four) {
            gate.SetTrigger ("On");
        }
    }
    public void Dialog () {
        dialog.SetActive (true);
        FindObjectOfType<AudioManager> ().Stop ("Coin");
		FindObjectOfType<AudioManager> ().Play ("Coin");
        GameObject.FindObjectOfType<GameManager> ().AddHonesty (15);
        GameObject.FindObjectOfType<LaserWeapon> ().numberOfBulletes += Random.Range (10, 15);
        GameObject.FindObjectOfType<LaserWeapon> ().ammoTextUI.text = GameObject.FindObjectOfType<LaserWeapon> ().numberOfBulletes.ToString ();
    }
}
