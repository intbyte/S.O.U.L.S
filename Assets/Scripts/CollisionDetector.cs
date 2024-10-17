using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {

    private MemoryBag bag;

    public GameObject memoryInstructionUI;
    public GameObject souldBodyInstructionUI;
    public GameObject switchInstructionUI;
    public GameObject gunInstructionUI;
    public GameObject bonusInstructionUI;
    public GameObject fireUI;
    public GameObject torchUI;

    public GameObject gun;

    public GameManager gameMan;

    public bool insideBody = false;

    [HideInInspector]
    public GameObject acquiredBody;

    string selectedTag = "None";

    bool hasFire = false;
    
    public void Start () {
        if (this.gameObject.GetComponent<MemoryBag> () == null) {
            Debug.LogWarning ("MemoryBag not found. Adding to gameObject...");
            this.gameObject.AddComponent<MemoryBag> ();
        }
        bag = this.gameObject.GetComponent<MemoryBag> ();
    }

    public void OnTriggerEnter2D (Collider2D collider) {
        if (collider.tag == "Lightning") {
            selectedTag = collider.tag;
        } else if (collider.tag == "Memory") {
            selectedTag = collider.tag;
            memoryInstructionUI.SetActive (true);
        } else if (collider.tag == "SoulBody") {
            selectedTag = collider.tag;
            souldBodyInstructionUI.SetActive (true);
        } else if (collider.tag == "Switch") {
            selectedTag = collider.tag;
            switchInstructionUI.SetActive (true);
        } else if (collider.tag == "Gun") {
            selectedTag = collider.tag;
            gunInstructionUI.SetActive (true);
        } else if (collider.tag == "Bonus") {
            bonusInstructionUI.SetActive (true);
            selectedTag = collider.tag;
        } else if (collider.tag == "Timer") {
            switchInstructionUI.SetActive (true);
            selectedTag = collider.tag;
        } else if (collider.tag == "Fire") {
            fireUI.SetActive (true);
            selectedTag = collider.tag;
        } else if (collider.tag == "Torch") {
            torchUI.SetActive (true);
            selectedTag = collider.tag;
        } else {
            selectedTag = "None";
        }
    }

    public void OnTriggerExit2D (Collider2D collider) {
        if (collider.tag == "Memory") {
            memoryInstructionUI.SetActive (false);
        } else if (collider.tag == "SoulBody") {
            souldBodyInstructionUI.SetActive (false);
        } else if (collider.tag == "Switch") {
            switchInstructionUI.SetActive (false);
        } else if (collider.tag == "Gun") {
            gunInstructionUI.SetActive (false);
        } else if (collider.tag == "Bonus") {
            bonusInstructionUI.SetActive (false);
        } else if (collider.tag == "Timer") {
            switchInstructionUI.SetActive (false);
        } else if (collider.tag == "Fire") {
            fireUI.SetActive (false);
        } else if (collider.tag == "Torch") {
            torchUI.SetActive (false);
        }
        selectedTag = "None";
    }

    Collider2D col;

    public void OnTriggerStay2D (Collider2D collider) {
        col = collider;
    }

    void Update () {
        if (selectedTag == "Lightning") {
            GetComponent<PlayerHealth> ().Damage (50f);
        } else if (selectedTag == "Memory") {
            if (Input.GetKeyDown (KeyCode.Space)) {
                CollectableMemory memory = col.gameObject.GetComponent<CollectableMemory> ();
                if (memory != null) {
                    GameObject.FindObjectOfType<GameManager> ().AddHonesty (20);
                    Debug.Log ("Memory found: " + memory.memory);
                    bag.CollectMemory (memory);
                    col.gameObject.SetActive (false);
                }
            }
        } else if (selectedTag == "SoulBody") {
            if (Input.GetKeyDown (KeyCode.Space) && acquiredBody == null) {
                Debug.Log ("Soul Body found.");
                col.gameObject.GetComponent<SoulBody> ().AcquireBody ();
            }
        } else if (selectedTag == "Switch") {
            if (Input.GetKeyDown (KeyCode.Space)) {
                Debug.Log ("Switching...");
                FindObjectOfType<AudioManager> ().Stop ("Switch");
		        FindObjectOfType<AudioManager> ().Play ("Switch");
                col.GetComponent<Switch> ().Toggle ();
            }
        } else if (selectedTag == "Gun") {
            if (Input.GetKeyDown (KeyCode.Space)) {
                Destroy (col.gameObject);
                gun.SetActive (true);
            }
        } else if (selectedTag == "Bonus") {
            if (Input.GetKeyDown (KeyCode.Space)) {
                Destroy (col.gameObject);
                FindObjectOfType<AudioManager> ().Stop ("Coin");
		        FindObjectOfType<AudioManager> ().Play ("Coin");
                transform.GetChild(0).GetComponent<LaserWeapon> ().numberOfBulletes += Random.Range (10, 15);
                transform.GetChild(0).GetComponent<LaserWeapon> ().ammoTextUI.text = transform.GetChild(0).GetComponent<LaserWeapon> ().numberOfBulletes.ToString ();
            }
        } else if (selectedTag == "Timer") {
            if (Input.GetKeyDown (KeyCode.Space )) {
                col.gameObject.GetComponent<TimerSwitch> ().StartTimer ();
            }
        } else if (selectedTag == "Fire") {
            if (Input.GetKeyDown (KeyCode.Space )) {
                hasFire = true;
            }
        } else if (selectedTag == "Torch") {
            if (Input.GetKeyDown (KeyCode.Space )) {
                if (hasFire) {
                    col.GetComponent<Torch> ().Lit ();
                    hasFire = false;
                }
            }
        }
    }
}
