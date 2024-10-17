using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLogic : MonoBehaviour {
    public List<Switch> switches;
    public List<bool> desiredValues;
    public bool gateOn = false;
    public Animator animator;
    public CameraMovement cam;
    void Update () {
        bool ok = true;
        for (int i = 0; i < Mathf.Min (switches.Count, desiredValues.Count); i++) {
            if (switches[i].on != desiredValues[i])
            ok = false;
        }
        if (gateOn && !ok) {
            animator.SetTrigger ("Off");
            StartCoroutine (cam.Shake (1, 0.15f));
            GetComponent<Collider2D> ().enabled = true;
            gateOn = false;
        } else if (gateOn && ok)
            return;
        else if (!gateOn && !ok)
            return;
        else if (!gateOn && ok) {
            animator.SetTrigger ("On");
            StartCoroutine (cam.Shake (1, 0.15f));
            GetComponent<Collider2D> ().enabled = false;
            gateOn = true;
        }
    }
}
