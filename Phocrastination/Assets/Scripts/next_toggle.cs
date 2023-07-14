using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public GameObject pad, redo, paintbrush;
    public GameObject beefOutline, brothOutline, herbsOutline, noodlesOutline;
    public GameObject beef, broth, herbs, noodles;
    public GameObject[] items;
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

            if (game_data.start_drawing) {  // reset counter at start of drawing_pad
                counter = 0;
            }

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                counter++;

                if (!game_data.help) {
                    if (counter == 1) {
                        beefOutline.SetActive(false);
                        brothOutline.SetActive(true);
                        clear();
                        game_data.start_drawing = false;
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

                        foreach (GameObject item in items) {
                            item.SetActive(true);
                        }

                        beef.transform.position = new Vector3(2.7f, 0.3f, 0f);
                        broth.transform.position = new Vector3(5.86f, 0.34f, 0f);
                        herbs.transform.position = new Vector3(2.67f, -0.85f, 0f);
                        noodles.transform.position = new Vector3(5.8f, -0.87f, 0f);

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