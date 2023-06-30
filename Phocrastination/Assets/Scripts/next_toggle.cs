using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public GameObject button, redo, instructions, pad;
    private int counter = 0;
    public GameObject beef, broth, herbs, noodles;
    public GameObject beefOutline, brothOutline, herbsOutline, noodlesOutline;
    public main_dot mainDot;

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
        pad.SetActive(false);
        beef.SetActive(false);
        broth.SetActive(false);
        herbs.SetActive(false);
        noodles.SetActive(false);
        beefOutline.SetActive(false);
        brothOutline.SetActive(false);
        herbsOutline.SetActive(false);
        noodlesOutline.SetActive(false);
        redo.SetActive(false);
        
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
                if (counter == 0) {
                    instructions.SetActive(false);
                    pad.SetActive(true);
                    beefOutline.SetActive(true);
                    redo.SetActive(true);
                    counter++;
                } else if (counter == 1) {
                    beefOutline.SetActive(false);
                    brothOutline.SetActive(true);
                    counter++;
                    clear();
                } else if (counter == 2) {
                    brothOutline.SetActive(false);
                    herbsOutline.SetActive(true);
                    counter++;
                    clear();
                } else if (counter == 3) {
                    herbsOutline.SetActive(false);
                    noodlesOutline.SetActive(true);
                    counter++;
                    clear();
                } else if (counter == 4) {
                    noodlesOutline.SetActive(false);
                    pad.SetActive(false);
                    redo.SetActive(false);
                    button.SetActive(false);
                    clear();

                    beef.SetActive(true);
                    broth.SetActive(true);
                    herbs.SetActive(true);
                    noodles.SetActive(true);
                }
            }
        }
    }
}