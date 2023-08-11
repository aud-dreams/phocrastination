using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day_pad_toggle : MonoBehaviour
{
    public GameObject[] items;
    private Renderer render;
    private new Collider collider;
    public game_data game_data;

    void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
        game_data.allow_timer = false;
    }

    private void OnMouseEnter()
    {
        render.enabled = true;
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

            if (collider.Raycast(ray, out hit, Mathf.Infinity))
            {
                foreach (GameObject item in items)
                {
                    item.SetActive(false);
                }

                game_data.allow_timer = true;
            }
        }
    }
}