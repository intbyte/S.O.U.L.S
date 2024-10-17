using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public GameManager manager;

	public float health;

	public Slider healthSlider;

	public GameObject damageEffect;

	public float interval1 = 0.1f;
	public float interval2 = 0.05f;

	bool animPlaying = false;

	public bool alive = true;

	PlayerMovement pm;

	public void Start () {
		health = 100f;
		healthSlider.value = health;
		pm = GetComponent<PlayerMovement> ();
		healthSlider.maxValue = 100f;
		healthSlider.wholeNumbers = true;
	}

	public void Damage (float damageValue) {
		if (!alive)
			return;
		health -= damageValue * Time.deltaTime;
		healthSlider.value = health;
		if (!animPlaying) {
			StartCoroutine (DamageEffect ());
		}
		if (health < 0)
			Die ();
	}

	public void Die () {
		alive = false;
		Debug.Log ("You died");
		// play death animation
		manager.GameOver ();
		return;
	}

	IEnumerator DamageEffect () {
		animPlaying = true;
		float elapsed = 0f;
		pm.enabled = false;
		damageEffect.SetActive (true);
		while (elapsed < interval1) {
			elapsed += Time.deltaTime;
			yield return null;
		}
		pm.enabled = true;
		elapsed = 0f;
		damageEffect.SetActive (false);
		while (elapsed < interval2) {
			elapsed += Time.deltaTime;
			yield return null;
		}
		animPlaying = false;
	}
}