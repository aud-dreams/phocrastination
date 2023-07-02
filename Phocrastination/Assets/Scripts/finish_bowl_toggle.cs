using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_bowl_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
    }

    private void OnMouseEnter() {
        if (game_data.beef_inside && game_data.broth_inside && game_data.herbs_inside && game_data.noodles_inside) {
            render.enabled = true;
        }
    }

    private void OnMouseExit() {
        render.enabled = false;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
                if (game_data.beef_inside && game_data.broth_inside && game_data.herbs_inside && game_data.noodles_inside) {
                    SceneManager.LoadScene("Main");
                }
            }
        }
    }
}
