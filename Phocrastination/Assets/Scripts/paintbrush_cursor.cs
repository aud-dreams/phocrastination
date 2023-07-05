using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintbrush_cursor : MonoBehaviour
{
    private new PolygonCollider2D collider;
    private SpriteRenderer render;
    public GameObject paintbrush;
    public game_data game_data;

    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
        render = paintbrush.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!collider.bounds.Contains(mousePosition)) {
            Cursor.visible = true;
            render.enabled = false;
        } else {
            if (game_data.allow_paintbrush) {
                render.enabled = true;
                Cursor.visible = false;
                paintbrush.transform.position = mousePosition;
            }
        }
    }
}
