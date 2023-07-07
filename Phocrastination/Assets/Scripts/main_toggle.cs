using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_toggle : MonoBehaviour
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
        render.enabled = true;
    }

    private void OnMouseExit() {
        render.enabled = false;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                SceneManager.LoadScene("Main");

                if (gameObject.CompareTag("Crafting")) {
                    game_data.crafting_continue = true;
                }
            }
        }
    }
}
