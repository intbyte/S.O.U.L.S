using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSwitch : MonoBehaviour
{
    public Phase4 p;
    bool on = false;
    public void StartTimer () {
        if (on)
            return;
        GetComponent<Animator> ().SetTrigger ("On");
        StartCoroutine (Wait ());
    }
    IEnumerator Wait () {
        on = true;
        p.OnAll ();
        yield return new WaitForSeconds (10.1f);
        p.OffAll ();
        on = false;
    }
}
