using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintbrush_cursor : MonoBehaviour
{
    private new PolygonCollider2D collider;
    private SpriteRenderer render;
    public GameObject paintbrush;
    public game_data game_data;
    public Sprite paintbrush_outline_color, paintbrush_beef_color, paintbrush_broth_color, paintbrush_herbs_color, paintbrush_noodles_color;

    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
        render = paintbrush.GetComponent<SpriteRenderer>();
        render.sprite = paintbrush_outline_color;
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (game_data.help) {      // if help on, cursor on
            Cursor.visible = true;
            render.enabled = false;
        } else {
            if (!collider.bounds.Contains(mousePosition)) {
                Cursor.visible = true;
                render.enabled = false;
            } else {
                if (game_data.allow_paintbrush) {
                    // paintbrush different colors
                    if (game_data.current_color == Color.black) { render.sprite = paintbrush_outline_color; }
                    if (game_data.current_color == HexToColor("#8d6042")) { render.sprite = paintbrush_beef_color; }
                    if (game_data.current_color == HexToColor("#cfa76e")) { render.sprite = paintbrush_broth_color; }
                    if (game_data.current_color == HexToColor("#507d4a")) { render.sprite = paintbrush_herbs_color; }
                    if (game_data.current_color == HexToColor("#f0ddb6")) { render.sprite = paintbrush_noodles_color; }

                    render.enabled = true;
                    Cursor.visible = false;
                    paintbrush.transform.position = mousePosition;
                }
            }
        }
    }

    private Color HexToColor(string hex) {
        Color color = Color.black;
        if (ColorUtility.TryParseHtmlString(hex, out color)) {
            return color;
        }
        return color;
    }
}
