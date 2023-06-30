using UnityEngine;

public class character_control : MonoBehaviour
{
    public Sprite spriteLeft;
    public Sprite spriteRight;
    public Sprite spriteFront;
    public Sprite spriteBack;
    public float movementSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Get horizontal and vertical input values
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Update velocity based on input
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * movementSpeed;
        rb.velocity = movement;

        // Update sprite based on direction
        if (horizontalInput < 0)
            spriteRenderer.sprite = spriteLeft;
        else if (horizontalInput > 0)
            spriteRenderer.sprite = spriteRight;
        else if (verticalInput > 0)
            spriteRenderer.sprite = spriteBack;
        else if (verticalInput < 0)
            spriteRenderer.sprite = spriteFront;
    }
}
