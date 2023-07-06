using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class drawing_pad : MonoBehaviour
{
    // drawing capability only when drawing_pad is active
    private bool isDrawing = false;
    public Transform baseDot;
    private BoxCollider2D drawingBounds;
    public game_data game_data;

    public EdgeCollider2D beef_collider;
    public EdgeCollider2D broth_collider; 
    public EdgeCollider2D herbs_collider;
    public EdgeCollider2D noodles_collider;
    public int total_dots;
    public int hit_dots;
    public float ratio_hit;

    void Start() 
    {
        drawingBounds = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            isDrawing = true;
        } else if (Input.GetMouseButtonUp(0)) {
            isDrawing = false;
        }

        if (isDrawing && game_data.allow_drawing && !game_data.help) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (drawingBounds.bounds.Contains(mousePosition)) {   // only allow drawing within bounds
                Instantiate(baseDot, mousePosition, baseDot.rotation).GetComponent<SpriteRenderer>().color = game_data.current_color;

                // count total dots
                if (game_data.current_color == Color.black) {
                    total_dots++;
                }
                else {
                    // do not increment
                    total_dots += 0;
                }
                

                // count hit dots for each edge collider
                if (Input.GetMouseButton(0)) {
                    if (game_data.current_color == Color.black && beef_collider != null && beef_collider.OverlapPoint(mousePosition)) {
                        hit_dots++;
                    }
                    else if (game_data.current_color == Color.black && broth_collider != null && broth_collider.OverlapPoint(mousePosition)) {
                        hit_dots++;
                    }
                    else if (game_data.current_color == Color.black && herbs_collider != null && herbs_collider.OverlapPoint(mousePosition)) {
                        hit_dots++;
                    }
                    else if (game_data.current_color == Color.black && noodles_collider != null && noodles_collider.OverlapPoint(mousePosition)) {
                        hit_dots++;
                    }
                    else if (game_data.current_color != Color.black) {
                        // do not increment
                        hit_dots += 0;
                    }
                }

                // calculate percentage hit
                ratio_hit = (float)hit_dots / total_dots;
                Debug.Log("Ratio hit: " + ratio_hit);
            }
        }
    }
}