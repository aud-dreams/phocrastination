using UnityEngine;

public class food_drag : MonoBehaviour
{
    Vector3 mousePositionOffset;
    public BoxCollider2D food;

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

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.bounds.Contains(food.bounds.min) && collider.bounds.Contains(food.bounds.max)) {
            // turn bools true
            // if 4 bools true, button activates

            if (this.CompareTag("Beef")) {
                Debug.Log("beef inside");
            }

            if (this.CompareTag("Broth")) {
                Debug.Log("broth inside");
            }

            if (this.CompareTag("Herbs")) {
                Debug.Log("herbs inside");
            }

            if (this.CompareTag("Noodles")) {
                Debug.Log("noodles inside");
            }
        }
    }
}