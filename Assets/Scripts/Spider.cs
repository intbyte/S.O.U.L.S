using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 endPos;
    public float speed = 5f;
    bool left = false;
    public bool horizontal = true;
    public bool vertical = false;
    public bool shouldAttack = false;
    public bool shouldMove = false;
    public GameObject enemyPrefab;
    public float delay = 3f;
    float currentTime = 0f;
    bool up = false;
    void Update()
    {
        if (shouldMove) {
            if (horizontal) {
                if (left) {
                    transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f);
                    if (transform.position.x < startPos.x)
                        left = false;
                } else {
                    transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
                    if (transform.position.x > endPos.x)
                        left = true;
                }
            } if (vertical) {
                if (!up) {
                    transform.position -= new Vector3 (0f, speed * Time.deltaTime, 0f);
                    if (transform.position.y < endPos.y)
                        up = true;
                } else {
                    transform.position += new Vector3 (0f, speed * Time.deltaTime, 0f);
                    if (transform.position.y > startPos.y)
                        up = false;
                }
            }
        }
        if (shouldAttack)
            Attack ();
    }
    void Attack () {
        if (currentTime > delay) {
            currentTime = 0f;
            GameObject enemy = Instantiate (enemyPrefab, transform.position, Quaternion.identity);
            enemy.GetComponent<PlayerFollower> ().target = GameObject.FindGameObjectWithTag ("Player").transform;
            enemy.GetComponent<PlayerFollower> ().rotateSpeed = Random.Range (300f, 500f);
            enemy.GetComponent<PlayerFollower> ().speed = Random.Range (5f, 10f);
        } else currentTime += Time.deltaTime;
    }
    void OnCollisionStay2D (Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            //FindObjectOfType<AudioManager> ().Stop ("Damage");
		    FindObjectOfType<AudioManager> ().Play ("Damage");
            collision.gameObject.GetComponent<PlayerHealth> ().Damage (30f);
        }
    }
}
