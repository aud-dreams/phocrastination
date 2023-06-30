using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawing_pad : MonoBehaviour
{
    // drawing capability only when drawing_pad is active
    private bool isDrawing = false;
    public Transform baseDot;
    private BoxCollider2D drawingBounds;

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

        if (isDrawing) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (drawingBounds.bounds.Contains(mousePosition)) {   // only allow drawing within bounds
                Instantiate(baseDot, mousePosition, baseDot.rotation);
            }
        }
    }
}
