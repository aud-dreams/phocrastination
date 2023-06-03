using UnityEngine;

public class bowl_drag : MonoBehaviour
{
    Vector3 mousePositionOffset;
    private new Collider collider;

    private void Start() {
        collider = GetComponent<Collider>();
    }

    private Vector3 GetMouseWorldPosition() {
        // capture mouse position & return WorldPoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown() {
        // capture mouse offset
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag() {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("collider")) {
            StartCoroutine(ShakeAndDisappear());
        }
    }

    private System.Collections.IEnumerator ShakeAndDisappear() {
        const float shakeDuration = 2f;
        const float shakeIntensity = 0.05f;
        const float shakeSpeed = 20f;

        Vector3 initialPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration) {
            float randomOffsetX = Mathf.PerlinNoise(Time.time * shakeSpeed, 0f) * 2f - 1f;
            float randomOffsetY = Mathf.PerlinNoise(0f, Time.time * shakeSpeed) * 2f - 1f;
            Vector3 shakeOffset = new Vector3(randomOffsetX, randomOffsetY, 0f) * shakeIntensity;

            transform.position = initialPosition + shakeOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                spawnPosition.z = 0f;
                transform.position = spawnPosition;
                gameObject.SetActive(true);
            }
        }
    }
}