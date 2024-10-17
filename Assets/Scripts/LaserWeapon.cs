using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserWeapon : MonoBehaviour {
    public Transform firePoint;
    public LineRenderer line;
    public float damage = 20f;
    public int numberOfBulletes = 100;
    public GameObject gunUI;
    public Text ammoTextUI;

    void Start () {
        gunUI.SetActive (true);
        ammoTextUI.text = numberOfBulletes.ToString ();
    }

    void Update() {
        if (Input.GetButtonDown ("Fire1")) {
            if (numberOfBulletes > 0) {
                FindObjectOfType<AudioManager> ().Stop ("Fire");
		        FindObjectOfType<AudioManager> ().Play ("Fire");
                StartCoroutine (Shoot ());
                numberOfBulletes--;
                ammoTextUI.text = numberOfBulletes.ToString ();
            } else Debug.Log ("No bullets");
        }
        Vector2 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

        Vector2 direction = mousePosition - (Vector2)transform.position;

        float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < -90 || angle > 90)
            transform.rotation = Quaternion.Euler (0, 180, 180 - angle);
        else
            transform.rotation = Quaternion.Euler (0, 0, angle);
    }

    IEnumerator Shoot () {
        RaycastHit2D hitInfo = Physics2D.Raycast (firePoint.position, firePoint.right);
        if (hitInfo) {
            Debug.Log (hitInfo.transform.name);
            line.SetPosition (0, firePoint.position);
            line.SetPosition (1, hitInfo.point);
            if (hitInfo.transform.gameObject.tag == "Explosive" || hitInfo.transform.gameObject.tag == "Enemy") {
                hitInfo.transform.gameObject.GetComponent<UniversalHealth> ().Damage (damage / Time.deltaTime);
                GameObject.FindObjectOfType<GameManager> ().AddHonesty (1);
            }
        } else {
            line.SetPosition (0, firePoint.position);
            line.SetPosition (1, (Vector2)firePoint.position + (Vector2)firePoint.right * 100f);
        }
        line.enabled = true;
        yield return new WaitForSeconds (0.025f);
        line.enabled = false;
    }
}
