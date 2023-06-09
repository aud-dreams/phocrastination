using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_pad_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;

    public GameObject[] items;
    public GameObject help, home, hand;
    private SpriteRenderer render2;

    void Start()
    {
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        render2 = hand.GetComponent<SpriteRenderer>();

        // set visibility at start
        render.enabled = false;

        if (game_data.first_cat_help) {
            help.SetActive(false);
            home.SetActive(false);
            game_data.allow_hand = false;
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

                game_data.allow_hand = true;

                help.SetActive(true);
                home.SetActive(true);
                game_data.first_cat_help = false;
                game_data.help = false;
            }
        }

        if (game_data.help) {
            game_data.allow_hand = false;
        }
        
        // // change cursor back
        // if (game_data.help) {
        //     Cursor.visible = true;
        //     render2.enabled = false;
        //     Debug.Log("hand off");
        // }
    }
}
