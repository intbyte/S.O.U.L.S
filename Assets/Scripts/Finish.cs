using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameManager gameMan;
    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.tag == "Player") {
            GameObject.FindObjectOfType<GameManager> ().Finish ();
        }
    }
}
