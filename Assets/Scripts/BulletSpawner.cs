using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootRate = 0.5f;
    float currentTime = 0f;
    float targetTime;
    void Update () {
        targetTime = 1f / shootRate;
        if (currentTime > targetTime) {
            currentTime = 0f;
            Instantiate (bulletPrefab, transform.position, Quaternion.identity, transform);
        } else currentTime += Time.deltaTime;
    }
}
