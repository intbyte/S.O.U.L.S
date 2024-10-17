using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLogic2 : MonoBehaviour {
    public List<Switch> switches;
    public List<bool> desiredValues;
    public bool gateOn = false;
    public Animator animator;
    void Update () {
        bool ok = true;
        for (int i = 0; i < Mathf.Min (switches.Count, desiredValues.Count); i++) {
            if (switches[i].on != desiredValues[i])
            ok = false;
        }
        if (!gateOn && ok) {
            animator.SetTrigger ("On");
            gateOn = true;
        }
    }
}
