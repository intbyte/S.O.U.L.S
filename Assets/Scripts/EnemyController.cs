using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject player;
    public GameObject warningRay;
    public GameObject lightningRay;
    public GameObject explosionPrefab;
    public CameraMovement camMvt;
    float currentTime = 0f, recordTime = 3f;
    bool record = true;
    void Update () {
        if (record)
            currentTime += Time.deltaTime;
        if (currentTime > recordTime) {
            warningRay.transform.position = player.transform.position;
            currentTime = 0f;
            StartCoroutine (WaitForWarning ());
        }
    }
    IEnumerator WaitForWarning () {
        record = false;
        warningRay.SetActive (true);
        yield return new WaitForSeconds (0.5f);
        warningRay.SetActive (false);
        StartCoroutine (camMvt.Shake (0.2f, 0.35f));
        Instantiate (lightningRay, warningRay.transform.position, Quaternion.identity);
        Instantiate (explosionPrefab, warningRay.transform.position, Quaternion.identity);
        record = true;
    }
}
