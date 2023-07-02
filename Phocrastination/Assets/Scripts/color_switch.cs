using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_switch : MonoBehaviour
{
    private Renderer render, render2;
    private new Collider collider;
    public GameObject baseDot;

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        render2 = baseDot.GetComponent<SpriteRenderer>();

        // set visibility at start
        render.enabled = false;
    }

    private void OnMouseEnter() {
        render.enabled = true;
    }

    private void OnMouseExit() {
        render.enabled = false;
    }

    private Color HexToColor(string hex) {
        Color color = Color.black;
        if (ColorUtility.TryParseHtmlString(hex, out color)) {
            return color;
        }
        return color;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                // switch base dot to new color
                if (this.CompareTag("OutlineColor")) {
                    render2.material.color = Color.black;
                    Debug.Log("change outline color");
                }

                if (this.CompareTag("BeefColor")) {
                    render2.material.color = HexToColor("#8d6042");
                    Debug.Log("change beef color");
                }

                if (this.CompareTag("BrothColor")) {
                    render2.material.color = HexToColor("#cfa76e");
                    Debug.Log("change broth color");
                }
                if (this.CompareTag("HerbsColor")) {
                    render2.material.color = HexToColor("#507d4a");
                    Debug.Log("change herbs color");
                }
                if (this.CompareTag("NoodlesColor")) {
                    render2.material.color = HexToColor("#f0ddb6");
                    Debug.Log("change noodles color");
                }

            }
        }
    }
}
