using UnityEngine;

public class food_drag : MonoBehaviour
{
    Vector3 mousePositionOffset;
    public BoxCollider2D food;
    public game_data game_data;

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
            // if all ingredients inside bowl, button activates
            if (this.CompareTag("Beef")) {
                game_data.beef_inside = true;
            }
            if (this.CompareTag("Broth")) {
                game_data.broth_inside = true;
            }
            if (this.CompareTag("Herbs")) {
                game_data.herbs_inside = true;
            }
            if (this.CompareTag("Noodles")) {
                game_data.noodles_inside = true;
            }
        } else {
            if (this.CompareTag("Beef")) {
                game_data.beef_inside = false;
            }
            if (this.CompareTag("Broth")) {
                game_data.broth_inside = false;
            }
            if (this.CompareTag("Herbs")) {
                game_data.herbs_inside = false;
            }
            if (this.CompareTag("Noodles")) {
                game_data.noodles_inside = false;
            }
        }
    }
}