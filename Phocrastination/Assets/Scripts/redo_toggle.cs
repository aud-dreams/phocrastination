using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redo_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public main_dot mainDot;

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        render.enabled = false;

        mainDot = FindObjectOfType<main_dot>();
    }

    private void OnMouseEnter() {
        render.enabled = true;
    }

    private void OnMouseExit() {
        render.enabled = false;
    }

    public void clear() {
        GameObject[] dots = GameObject.FindGameObjectsWithTag("Dot");
        foreach (GameObject dot in dots) { 
            if (dot != mainDot.gameObject) {    // don't destroy main dot
                Destroy(dot); 
            }
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                clear();
            }
        }
    }
}
