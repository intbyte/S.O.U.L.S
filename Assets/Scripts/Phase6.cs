using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase6 : MonoBehaviour
{
    public Spider spider;
    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == "Player") {
            spider.shouldAttack = true;
            spider.shouldMove = true;
        }
    }
    void OnTriggerExit2D (Collider2D col) {
        if (col.tag == "Player") {
            spider.shouldAttack = false;
            spider.shouldMove = false;
        }
    }
}
