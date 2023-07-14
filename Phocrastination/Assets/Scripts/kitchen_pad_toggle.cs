using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchen_pad_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;

    public main_dot mainDot;
    public GameObject[] start, items, ingredients, colorSwitches;
    private SpriteRenderer paintbrush_render;

    private void Start() {        
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        game_data.allow_drawing = false;

        // set visibility at start
        render.enabled = false;

        foreach (GameObject item in items) { item.SetActive(false); }
        foreach (GameObject i in ingredients) { i.SetActive(false); }
        foreach (GameObject colorSwitch in colorSwitches) { colorSwitch.SetActive(false); }
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
                foreach (GameObject s in start) {
                    s.SetActive(false);
                }

                game_data.allow_drawing = true;

                game_data.help = false;

                foreach (GameObject item in items) { item.SetActive(true); }
                foreach (GameObject colorSwitch in colorSwitches) { colorSwitch.SetActive(true); }
                
                game_data.first_crafting_help = false;
                game_data.allow_paintbrush = true;
                game_data.start_drawing = true;
            }
        }
    }
}
