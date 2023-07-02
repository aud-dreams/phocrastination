using UnityEngine;

public class bowl_drag : MonoBehaviour
{
    Vector3 mousePositionOffset;
    public game_data game_data;
    public int dirty_bowls;
    public int clean_bowls;

    private void Start() {
    }

    private Vector3 GetMouseWorldPosition() {
        // capture mouse position & return WorldPoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown() {
        // capture mouse offset
        mousePositionOffset = transform.position - GetMouseWorldPosition();
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

        dirty_bowls = game_data.dirty_bowls;
        clean_bowls = game_data.clean_bowls;
        dirty_bowls -= 1;
        clean_bowls += 1;

        Debug.Log(dirty_bowls);
        Debug.Log(clean_bowls);

        game_data.dirty_bowls = dirty_bowls;
        game_data.clean_bowls = clean_bowls;
        game_data.firstClick = 0;
    }
}