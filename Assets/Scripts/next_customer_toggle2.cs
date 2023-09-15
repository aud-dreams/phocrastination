using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_customer_toggle2 : MonoBehaviour
{
    private Renderer render, bowl_render;
    private new Collider collider;
    public game_data game_data;
    public GameObject bowl, button, toggle;
    private Vector3 bowl_position = new Vector3(1.67f, 0.31f, 0f);

    private void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        bowl_render = bowl.GetComponent<Renderer>();

        // set visibility at start
        render.enabled = false;
    }

    private void OnMouseEnter()
    {
        if (game_data.can_next2)
        {
            render.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        render.enabled = false;
    }

    public void Lighten()
    {
        Renderer renderer2 = game_data.ordered_line[0].GetComponent<SpriteRenderer>();
        float lightenAmount = 1.53f;
        Color light = new Color(renderer2.material.color.r * lightenAmount, renderer2.material.color.g * lightenAmount, renderer2.material.color.b * lightenAmount, renderer2.material.color.a);
        renderer2.material.color = light;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                if (game_data.can_next2 && !game_data.help)
                {
                    // "instantiate" bowl if orders are still left
                    if (game_data.constructed_orders != 0)
                    {
                        bowl.transform.position = bowl_position;
                        bowl_render.enabled = true;
                        game_data.allow_drag = true;
                    }

                    button.SetActive(false);
                    toggle.SetActive(false);

                    // all customers shift left & front customer turns active & light
                    foreach (GameObject customer in game_data.ordered_line)
                    {
                        customer.transform.position += new Vector3(-1f, 0f, 0f);
                    }
                    Lighten();
                    game_data.ordered_line[0].SetActive(true);

                    game_data.can_next2 = false;
                }
            }
        }
    }
}
