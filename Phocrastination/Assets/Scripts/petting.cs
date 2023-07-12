using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petting : MonoBehaviour
{
    private new PolygonCollider2D collider;
    private SpriteRenderer render;
    public GameObject hand;
    public game_data game_data;

    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
        render = hand.GetComponent<SpriteRenderer>();
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        render.enabled = false;
        
        if (game_data.allow_hand) {
            if (collider.bounds.Contains(mousePosition)) {
                render.enabled = true;
                Cursor.visible = false;
                hand.transform.position = mousePosition;
            }
            else {
                Cursor.visible = true;
                render.enabled = false;   
            }
        }
    }
}
