using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_bowl_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;
    public GameObject[] items;
    public GameObject bowl_complete, next_bowl_button, brothOutline, herbsOutline, noodlesOutline;

    private void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
    }

    private void OnMouseEnter()
    {
        if (!game_data.help)
        {
            render.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        render.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                if (!game_data.help)
                {
                    foreach (GameObject item in items) { item.SetActive(true); }
                    game_data.allow_paintbrush = true;
                    game_data.allow_drawing = true;
                    bowl_complete.SetActive(false);
                    next_bowl_button.SetActive(false);
                    gameObject.SetActive(false);

                    brothOutline.SetActive(false);
                    herbsOutline.SetActive(false);
                    noodlesOutline.SetActive(false);
                    game_data.current_color = Color.black;
                    game_data.crafting = true;
                }
            }
        }
    }
}