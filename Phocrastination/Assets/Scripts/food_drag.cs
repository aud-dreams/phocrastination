using UnityEngine;

public class food_drag : MonoBehaviour
{
    Vector3 mousePositionOffset;

    private void Start() {
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
            // detect has entered bowl
        }
    }
}