using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool lit = false;
    public GameObject fire;
    public void Lit () {
        if (lit)
            return;
        lit = true;
        fire.SetActive (true);
        GameObject.FindObjectOfType<Phase5> ().UpdateGate ();
    }
}
