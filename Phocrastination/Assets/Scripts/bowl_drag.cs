using UnityEngine;
using System.Collections;
using Proyecto26;

public class bowl_drag : MonoBehaviour
{
    Vector3 mousePositionOffset;
    public game_data game_data;
    public stat_data stat_data;
    private int dirty_bowls, clean_bowls;

    public BoxCollider2D bowl;
    private int collisions = 0;
    private bool washing_complete = false;

    public Sprite clean_bowl, dirty_bowl;
    private SpriteRenderer render;
    public GameObject home;

    user_log user = new user_log();

    private void Start()
    {
        bowl = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();
        render.enabled = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // capture mouse position & return WorldPoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        // capture mouse offset
        if (game_data.allow_bowls)
        {
            render.enabled = true;
            mousePositionOffset = transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseDrag()
    {
        if (game_data.allow_bowls)
        {
            render.enabled = true;
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D sink)
    {
        if (sink.CompareTag("collider"))
        {
            // if bowl in sink, increment collisions
            if (washing_complete == false)
            {
                collisions++;

                // check if washing is complete
                if (collisions >= 20)
                {
                    // reset
                    collisions = 0;
                    washing_complete = true;
                }

                // dirty -> clean bowl
                if (washing_complete == true)
                {
                    washing_complete = false;

                    // convert to clean
                    render.sprite = clean_bowl;

                    // wait for 1 second
                    yield return new WaitForSeconds(1.0f);

                    // disappear
                    gameObject.SetActive(false);
                    game_data.washing = false;

                    // convert to dirty
                    render.sprite = dirty_bowl;

                    dirty_bowls = game_data.dirty_bowls;
                    dirty_bowls -= 1;
                    clean_bowls += 1;

                    game_data.dirty_bowls = dirty_bowls;

                    // reset isFirstClick
                    stat_data.isFirstClick = true;

                    if (game_data.dirty_bowls == 0 && game_data.tutorial)
                    {
                        game_data.dishes_blink = true;
                        home.SetActive(true);
                    }

                    // post to database
                    if (!game_data.tutorial) {
                        user.bowl_washed_ts2 = game_data.timer;
                        RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
                    }
                }
            }
        }
    }
}