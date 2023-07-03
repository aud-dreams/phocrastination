using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class main_pad_toggle : MonoBehaviour
{
    public game_data game_data;
    private Renderer render;
    private new Collider collider;

    public SpriteRenderer main_pad1, main_pad2, main_pad3;
    public GameObject[] start;
    public GameObject[] toggles;

    private int click = 1;

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
                if (click == 1) {
                    main_pad2.enabled = true;
                    main_pad1.enabled = false;
                    click += 1;
                } else if (click == 2) {
                    main_pad3.enabled = true;
                    main_pad2.enabled = false;
                    click += 1;
                } else if (click == 3) {
                    // disable all menu sprites
                    foreach (GameObject item in start) {
                        item.SetActive(false);
                    }
                    // enable all toggles
                    foreach (GameObject item in toggles) {
                        item.SetActive(true);
                    }
                    game_data.menu_on = false;
                }
                
            }
        }
    }
}
