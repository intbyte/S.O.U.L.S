using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBall : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float lifeTime = 6f;
    Rigidbody2D rb;
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }
    void OnCollisionEnter2D (Collision2D collider) {
        if (collider.gameObject.tag == "Player") {
            Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            Destroy (gameObject);
        }
    }
    float currentTime = 0f;
    void Update () {
        if (currentTime > lifeTime) {
            Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            Destroy (gameObject);
        } else currentTime += Time.deltaTime;
    }
}
