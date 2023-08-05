using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_bar : MonoBehaviour
{
    public GameObject red, home;
    public game_data game_data;
    private SpriteRenderer toggle_render;


    void Start() {
        // set progress bar decreased over time
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
        if (!game_data.hand_on && red.transform.localScale.x > 0 && !game_data.help && !game_data.first_cat_help) {
            // progress slowly decrement over time
            red.transform.position = red.transform.position - new Vector3(0.0000099999f, 0f, 0f);
            red.transform.localScale = red.transform.localScale - new Vector3(0.00001f, 0f, 0f);
            game_data.progress_position = red.transform.position;
            game_data.progress_scale = red.transform.localScale;
        }

        if (game_data.tutorial) {
            if (game_data.progress_position.x >= -0.85 && game_data.cat_blink) {
                home.SetActive(true);
                StartCoroutine(blink(home));
                game_data.cat_blink = false;
                game_data.home_on = true;
            }
        }
    }

    private IEnumerator blink(GameObject toggle)
    {
        toggle_render = toggle.GetComponent<SpriteRenderer>();
        for (int i = 0; i < 5; i++)
        {
            toggle_render.enabled = true;
            yield return new WaitForSeconds(0.3f);
            toggle_render.enabled = false;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
