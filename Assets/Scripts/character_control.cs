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
    public game_data game_data;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (!game_data.first_day1_help && !game_data.first_day2_help && !game_data.first_day3_help)
        {
            transform.position = game_data.character_position;
            spriteRenderer.sprite = game_data.character_sprite;
        }
    }

    private void Update()
    {
        // Get horizontal and vertical input values
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Update velocity based on input
        if (game_data.allow_move)
        {
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
}
