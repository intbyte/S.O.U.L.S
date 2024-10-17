using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrisonBreak : MonoBehaviour
{
    public UnityEvent breakEvents;
    void OnTriggerEnter2D (Collider2D collider) {
        if (collider.tag == "Player") {
            breakEvents.Invoke ();
            Destroy (gameObject);
        }
    }
}
