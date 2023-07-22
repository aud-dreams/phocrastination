using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowl_pickup : MonoBehaviour
{
    public game_data game_data;
    Vector3 mousePositionOffset;
    public BoxCollider2D bowl;
    private SpriteRenderer render;

    private void Start() {
        bowl = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private Vector3 GetMouseWorldPosition() {
        // capture mouse position & return WorldPoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown() {
        // capture mouse offset
        if (game_data.allow_bowls) {
            mousePositionOffset = transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseDrag() {
        if (game_data.allow_bowls) {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }
    }

    private void OnTriggerEnter2D(Collider2D customer) {
        if (customer.CompareTag("collider")) {
            gameObject.SetActive(false);
            game_data.received = true;
        }
    }
}
