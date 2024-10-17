using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBody : MonoBehaviour {
    public GameObject player;
    public Vector3 releasePositionOffset;
    private bool acquired = false;
    public GameObject glowBody;
    public GameObject regularBody;
    public void AcquireBody () {
        Debug.Log ("Body " + this.gameObject.name + " is acquired by the soul.");
        acquired = true;
        player.transform.SetParent (transform);
        player.transform.localPosition = Vector2.zero;
        player.SetActive (false);
        //GetComponent<PlayerMovement> ().enabled = true;
        player.GetComponent<CollisionDetector> ().insideBody = true;
        player.GetComponent<CollisionDetector> ().acquiredBody = this.gameObject;
        glowBody.SetActive (true);
        regularBody.SetActive (false);
    }

    public void LeaveBody () {
        Debug.Log ("The soul left the body.");
        acquired = false;
        transform.DetachChildren ();
        //GetComponent<PlayerMovement> ().enabled = false;
        player.GetComponent<PlayerMovement> ().enabled = true;
        player.transform.position = transform.position + releasePositionOffset;
        player.SetActive (true);
        player.GetComponent<CollisionDetector> ().insideBody = false;
        player.GetComponent<CollisionDetector> ().acquiredBody = null;
        glowBody.SetActive (false);
        regularBody.SetActive (true);
    }

    public void Update () {
        if (acquired) {
            if (Input.GetKeyDown (KeyCode.Space)) {
                LeaveBody ();
            }
        }
    }

    void OnMouseOver () {
        if (!acquired && player.GetComponent<CollisionDetector> ().insideBody) {
            if (Input.GetMouseButtonDown (0)) {
                player.GetComponent<CollisionDetector> ().acquiredBody.GetComponent<SoulBody> ().LeaveBody ();
                AcquireBody ();
            }
        }
    }
}
