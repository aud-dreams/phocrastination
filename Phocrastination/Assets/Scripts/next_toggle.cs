using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public GameObject finish_bowl_button, finish_bowl_toggle, pad, redo;
    public GameObject beef, broth, herbs, noodles;
    public GameObject beefOutline, brothOutline, herbsOutline, noodlesOutline;
    public main_dot mainDot;
    private int counter = 0;

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
        beefOutline.SetActive(true);
        
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
                    beefOutline.SetActive(false);
                    brothOutline.SetActive(true);
                    counter++;
                    clear();
                } else if (counter == 1) {
                    brothOutline.SetActive(false);
                    herbsOutline.SetActive(true);
                    counter++;
                    clear();
                } else if (counter == 2) {
                    herbsOutline.SetActive(false);
                    noodlesOutline.SetActive(true);
                    counter++;
                    clear();
                } else if (counter == 3) {
                    noodlesOutline.SetActive(false);
                    pad.SetActive(false);
                    redo.SetActive(false);
                    gameObject.SetActive(false);
                    clear();

                    beef.SetActive(true);
                    broth.SetActive(true);
                    herbs.SetActive(true);
                    noodles.SetActive(true);
                    finish_bowl_button.SetActive(true);
                    finish_bowl_toggle.SetActive(true);
                }
            }
        }
    }
}