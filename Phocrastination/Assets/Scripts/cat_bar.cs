using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_bar : MonoBehaviour
{
    public GameObject red;
    public game_data game_data;

    void Start() {
        // set initial/previous progress bar
        red.transform.position = game_data.progress_position;
        red.transform.localScale = game_data.progress_scale;

    }

    private void OnTriggerEnter2D(Collider2D cat) {
        if (cat.CompareTag("collider")) {
            // every collision increments progress bar
            if (red.transform.localScale.x <= 1.35) {
                red.transform.position = red.transform.position + new Vector3(0.0099999f, 0f, 0f);
                red.transform.localScale = red.transform.localScale + new Vector3(0.01f, 0f, 0f);
                game_data.progress_position = red.transform.position;
                game_data.progress_scale = red.transform.localScale;
            }
        }
    }

    void Update() {
        if (!game_data.hand_on && red.transform.localScale.x > 0) {
            // progress slowly decrement over time
            red.transform.position = red.transform.position - new Vector3(game_data.x_transform, 0f, 0f);
            red.transform.localScale = red.transform.localScale - new Vector3(game_data.x_scale, 0f, 0f);
        }
    }
}
