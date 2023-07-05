using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchen_pad_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;
    public GameObject[] items;

    public GameObject finish_bowl_button, finish_bowl_toggle, next, redo, help, home;
    public GameObject beef, broth, herbs, noodles;
    public GameObject beefOutline, brothOutline, herbsOutline, noodlesOutline;
    public main_dot mainDot;
    public GameObject outlineColorSwitch, beefColorSwitch, brothColorSwitch, herbsColorSwitch, noodlesColorSwitch;

    private void Start() {        
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        game_data.allow_drawing = false;

        // set visibility at start
        render.enabled = false;
        next.SetActive(false);
        beef.SetActive(false);
        broth.SetActive(false);
        herbs.SetActive(false);
        noodles.SetActive(false);
        beefOutline.SetActive(false);
        brothOutline.SetActive(false);
        herbsOutline.SetActive(false);
        noodlesOutline.SetActive(false);
        redo.SetActive(false);
        finish_bowl_button.SetActive(false);
        finish_bowl_toggle.SetActive(false);

        outlineColorSwitch.SetActive(false);
        beefColorSwitch.SetActive(false);
        brothColorSwitch.SetActive(false);
        herbsColorSwitch.SetActive(false);
        noodlesColorSwitch.SetActive(false);

        if (game_data.first_crafting_help) {
            help.SetActive(false);
            home.SetActive(false);
        }
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
                foreach (GameObject item in items) {
                    item.SetActive(false);
                }

                game_data.allow_drawing = true;

                redo.SetActive(true);
                next.SetActive(true);
                outlineColorSwitch.SetActive(true);
                beefColorSwitch.SetActive(true);
                brothColorSwitch.SetActive(true);
                herbsColorSwitch.SetActive(true);
                noodlesColorSwitch.SetActive(true);
                beefOutline.SetActive(true);

                help.SetActive(true);
                home.SetActive(true);

                game_data.first_crafting_help = false;
                game_data.help = false;
                game_data.allow_paintbrush = true;
            }
        }
    }
}
