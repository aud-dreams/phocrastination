using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petting : MonoBehaviour
{
    private new BoxCollider2D collider;
    private SpriteRenderer render;
    public GameObject hand;
    public game_data game_data;
    public AudioSource src;
    public AudioClip purr;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        render = hand.GetComponent<SpriteRenderer>();
        game_data.allow_hand = true;
        game_data.hand_on = true;

        src.clip = purr;
        src.loop = true;
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        render.enabled = false;

        if (game_data.allow_hand)
        {
            if (collider.bounds.Contains(mousePosition))
            {
                render.enabled = true;
                Cursor.visible = false;
                hand.transform.position = mousePosition;
                game_data.hand_on = true;
            }
            else
            {
                Cursor.visible = true;
                render.enabled = false;
                game_data.hand_on = false;

                // play cat purr sound
                src.Play();
            }
        }
    }
}
