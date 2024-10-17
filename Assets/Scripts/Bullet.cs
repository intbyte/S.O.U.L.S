using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float lifeTime = 1f;
    public float speed = 5f;
    void OnCollisionEnter2D (Collision2D collider) {
        if (collider.gameObject.tag == "Player") {
            Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager> ().Stop ("Explosion");
		    FindObjectOfType<AudioManager> ().Play ("Explosion");
            collider.gameObject.GetComponent<PlayerHealth> ().Damage (30f / Time.deltaTime);
            Destroy (gameObject);
        } else if (collider.gameObject.tag == "Barier") {
            Destroy (gameObject);
        }
    }
    float currentTime = 0f;
    void Update () {
        if (currentTime > lifeTime) {
            Instantiate (explosionPrefab, transform.position, Quaternion.identity);
            Destroy (this.gameObject);
        } else currentTime += Time.deltaTime;
        transform.localPosition += new Vector3 (speed * Time.deltaTime, 0f, 0f);
    }
}
