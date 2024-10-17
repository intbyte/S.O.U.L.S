using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour {
    public bool on = false;
    public UnityEvent onEvent;
    public UnityEvent offEvent;
    public Animator animator;
    public void Toggle () {
        on = !on;
        animator.SetBool ("Value", on);
    }
    public void OnEvent () {
        onEvent.Invoke ();
    }
    public void OffEvent () {
        offEvent.Invoke ();
    }
}
