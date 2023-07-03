using UnityEngine;

public class bowl_drag : MonoBehaviour
{
    Vector3 mousePositionOffset;
    public game_data game_data;
    public int dirty_bowls;
    public int clean_bowls;

    public BoxCollider2D bowl;
    public int collisions;
    public bool washing_complete;

    private void Start() {
        bowl = GetComponent<BoxCollider2D>();
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

    private void OnTriggerEnter2D(Collider2D sink) {
        if (sink.CompareTag("collider")) {
            collisions = game_data.collisions;
            washing_complete = game_data.washing_complete;

            // if bowl in sink, increment collisions
            if (washing_complete == false) {
                collisions++;
                game_data.collisions = collisions;

                // check if washing is complete
                if (collisions >= 20) {
                    // reset
                    collisions = 0;
                    Debug.Log(collisions);
                    game_data.collisions = collisions;

                    washing_complete = true;
                    Debug.Log(washing_complete);
                    game_data.washing_complete = true;
                }

                // dirty -> clean bowl
                if (washing_complete == true) {
                    washing_complete = false;
                    Debug.Log(washing_complete);
                    game_data.washing_complete = false;

                    // convert sprite

                    // disappear
                    gameObject.SetActive(false);

                    dirty_bowls = game_data.dirty_bowls;
                    clean_bowls = game_data.clean_bowls;
                    dirty_bowls -= 1;
                    clean_bowls += 1;

                    Debug.Log(dirty_bowls);
                    Debug.Log(clean_bowls);

                    game_data.dirty_bowls = dirty_bowls;
                    game_data.clean_bowls = clean_bowls;
                }
            }
        }
    }
}