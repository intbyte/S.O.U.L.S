using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase3 : MonoBehaviour
{
    public BulletSpawner canon;
    public Spider spider;
    public GameObject bulletBonus;
    public Animator gate1Animator;
    bool on = false;
    public void OnTriggerEnter2D (Collider2D collider) {
        if (on)
            return;
        if (collider.tag == "Player") {
            canon.enabled = true;
            spider.shouldAttack = true;
            spider.shouldMove = true;
            on = true;
            //Destroy (gameObject);
        }
    }
    public void PutBonus () {
        GameObject.FindObjectOfType<GameManager> ().AddHonesty (10);
        Instantiate (bulletBonus, spider.transform.position, Quaternion.identity);
        Debug.Log ("Bonus");
        gate1Animator.SetTrigger ("On");
        Debug.Log ("GateOn");
    }
}
