using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class drawing_pad : MonoBehaviour
{
    // drawing capability only when drawing_pad is active
    private bool isDrawing = false;
    public Transform baseDot;
    private BoxCollider2D drawingBounds;
    public game_data game_data;
    public stat_data stat_data;

    public EdgeCollider2D beef_collider;
    public EdgeCollider2D broth_collider;
    public EdgeCollider2D herbs_collider;
    public EdgeCollider2D noodles_collider;
    public int total_dots;
    public int hit_dots;
    public float ratio_hit;

    // public AudioSource src;
    // public AudioClip paint;

    user_log user = new user_log();

    void Start()
    {
        drawingBounds = GetComponent<BoxCollider2D>();
        game_data.pad_on = true;

        // src.clip = paint;
        // src.loop = true;
    }

    void Update()
    {
        game_data.pad_on = true;

        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;

            // get start drawing time ONCE
            if (stat_data.has_start_drawing)
            {
                stat_data.start_drawing = game_data.timer;

                stat_data.has_start_drawing = false;
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }

        if (isDrawing && game_data.allow_drawing && !game_data.help)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (drawingBounds.bounds.Contains(mousePosition))
            {   // only allow drawing within bounds
                Instantiate(baseDot, mousePosition, baseDot.rotation).GetComponent<SpriteRenderer>().color = game_data.current_color;

                //src.Play();

                // count total dots
                if (game_data.current_color == Color.black)
                {
                    total_dots++;
                }
                else
                {
                    // do not increment
                    total_dots += 0;
                }

                // count hit dots for each edge collider
                if (Input.GetMouseButton(0))
                {
                    if (game_data.current_color == Color.black && beef_collider != null && beef_collider.OverlapPoint(mousePosition))
                    {
                        hit_dots++;
                    }
                    else if (game_data.current_color == Color.black && broth_collider != null && broth_collider.OverlapPoint(mousePosition))
                    {
                        hit_dots++;
                    }
                    else if (game_data.current_color == Color.black && herbs_collider != null && herbs_collider.OverlapPoint(mousePosition))
                    {
                        hit_dots++;
                    }
                    else if (game_data.current_color == Color.black && noodles_collider != null && noodles_collider.OverlapPoint(mousePosition))
                    {
                        hit_dots++;
                    }
                    else if (game_data.current_color != Color.black)
                    {
                        // do not increment
                        hit_dots += 0;
                    }
                }

                // calculate percentage hit
                ratio_hit = (float)hit_dots / total_dots;
                stat_data.ratio_hit = ratio_hit;

                // post to database
                if (!game_data.tutorial)
                {
                    if (stat_data.isFirstDot)
                    {
                        user.bowl_created_ts1 = game_data.timer;
                        RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
                        stat_data.isFirstDot = false;
                    }
                }
            }
        }
    }
}