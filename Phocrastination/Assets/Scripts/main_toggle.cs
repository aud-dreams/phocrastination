using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        SetVisibility(false);
    }

    private void OnMouseEnter() {
        SetVisibility(true);
    }

    private void OnMouseExit() {
        SetVisibility(false);
    }

    private void SetVisibility(bool isVisible) {
        render.enabled = isVisible;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                SceneManager.LoadScene("Main");
            }
        }
    }
}
