using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public Transform targetToFollow;

	public Vector3 offset;

	Camera mainCamera;

	public float smoothSpeed = 0.02f;

    public bool zoomEffect = false;
    [Range (1f, 3f)]
    public float magnification = 1f;

    float initialSize = 5f;

	void Start () {
		mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
        initialSize = mainCamera.orthographicSize;
	}

	void FixedUpdate () {
		Vector2 desiredPosition = targetToFollow.position + offset;
        float distance = Vector2.Distance ((Vector2)transform.position, desiredPosition);
        if (zoomEffect) {
            float desiredMagnification = Mathf.Lerp (initialSize, initialSize * magnification, distance / 5f);
            if (Mathf.Abs (desiredMagnification - initialSize) < 0.01f)
                mainCamera.orthographicSize = initialSize;
            else
                mainCamera.orthographicSize = desiredMagnification;
        }
        if (distance < 0.001f)
            return;
		Vector2 smoothingOperation = Vector2.Lerp (transform.position, desiredPosition, smoothSpeed);
		transform.position = new Vector3 (smoothingOperation.x, smoothingOperation.y, -10);
	}

    public IEnumerator Shake (float duration, float magnitude) {
		//Vector3 originalPos = mainCamera.transform.localPosition;

		float elasped = 0.0f;

		while (elasped < duration) {
			float x = Random.Range (-1f * elasped / duration, 1f * elasped / duration) * magnitude;
			float y = Random.Range (-1f * elasped / duration, 1f * elasped / duration) * magnitude;

			mainCamera.transform.localPosition = mainCamera.transform.localPosition + new Vector3 (x, y, 0f);

			elasped += Time.deltaTime;

			yield return null;
		}
		//mainCamera.transform.localPosition = originalPos;
	}
}