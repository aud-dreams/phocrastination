using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class copy_ID : MonoBehaviour
{
    public game_data game_data;
    private Renderer render;
    private new Collider collider;
    public string userID;

    private void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        userID = game_data.userID;
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

    // public void Lighten()
    // {
    //     Renderer renderer2 = game_data.ordered_line[0].GetComponent<SpriteRenderer>();
    //     float lightenAmount = 1.53f;
    //     Color light = new Color(renderer2.material.color.r * lightenAmount, renderer2.material.color.g * lightenAmount, renderer2.material.color.b * lightenAmount, renderer2.material.color.a);
    //     renderer2.material.color = light;
    // }

    public void CopyToClipboard()
    {
        GUIUtility.systemCopyBuffer = userID;
        Debug.Log("Unique ID copied to clipboard: " + userID);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                // Lighten();
                CopyToClipboard();
            }
        }
    }
}