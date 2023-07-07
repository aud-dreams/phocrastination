using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public GameObject pad, redo, paintbrush;
    public GameObject beef, broth, herbs, noodles;
    public GameObject beefOutline, brothOutline, herbsOutline, noodlesOutline;
    public main_dot mainDot;
    private int counter = 0;
    public game_data game_data;
    private SpriteRenderer paintbrush_render;

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
        paintbrush_render = paintbrush.GetComponent<SpriteRenderer>();
        beefOutline.SetActive(true);
        
        mainDot = FindObjectOfType<main_dot>();
    }

    private void OnMouseEnter() {
        if (!game_data.help) {
            render.enabled = true;
        }
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
                counter++;

                if (!game_data.help) {
                    if (counter == 1) {
                        beefOutline.SetActive(false);
                        brothOutline.SetActive(true);
                        clear();
                    } else if (counter == 2) {
                        brothOutline.SetActive(false);
                        herbsOutline.SetActive(true);
                        clear();
                    } else if (counter == 3) {
                        herbsOutline.SetActive(false);
                        noodlesOutline.SetActive(true);
                        clear();
                    } else if (counter == 4) {
                        noodlesOutline.SetActive(false);
                        pad.SetActive(false);
                        redo.SetActive(false);
                        gameObject.SetActive(false);
                        clear();

                        beef.SetActive(true);
                        broth.SetActive(true);
                        herbs.SetActive(true);
                        noodles.SetActive(true);

                        game_data.allow_drawing = false;

                        // turn cursor back on
                        game_data.allow_paintbrush = false;
                        Cursor.visible = true;
                        paintbrush_render.enabled = false;
                    }
                }
            }
        }
    }
}