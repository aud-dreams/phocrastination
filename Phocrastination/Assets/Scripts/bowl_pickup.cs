using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class bowl_pickup : MonoBehaviour
{
    public game_data game_data;
    public stat_data stat_data;
    Vector3 mousePositionOffset;
    private SpriteRenderer render;
    private Renderer bowl_render;
    public GameObject bowl, button, toggle, sparkles, home;
    private Vector3 bowl_position = new Vector3(1.67f, 0.31f, 0f);
    public EdgeCollider2D wall;

    user_log user = new user_log();

    private void Start() {
        render = GetComponent<SpriteRenderer>();
        bowl_render = bowl.GetComponent<Renderer>();

        if (game_data.constructed_orders != 0) {
            bowl.SetActive(true);
            bowl.transform.position = bowl_position;
            bowl_render.enabled = true;
        } else {
            bowl.SetActive(false);
        }
    }

    private Vector3 GetMouseWorldPosition() {
        // capture mouse position & return WorldPoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown() {
        // capture mouse offset
        if (game_data.allow_drag) {
            mousePositionOffset = transform.position - GetMouseWorldPosition();
        }

        // first click only
        if (stat_data.isFirstClick2) {
            user.order_given_ts1 = game_data.timer;
            RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);
            stat_data.isFirstClick = false;
        }
    }

    private void OnMouseDrag() {
        if (game_data.allow_drag) {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }
    }

    private void OnTriggerEnter2D(Collider2D customer) {
        if (customer.CompareTag("collider")) {
            render.enabled = false;
            home.SetActive(false);

            if (game_data.once) {
                // first customer in line leaves
                game_data.ordered_customers--;
                StartCoroutine(Pickup(game_data.ordered_line[0]));
                game_data.ordered_line.RemoveAt(0);
                game_data.once = false;
            }
                    
            // once button clicked, deactivate button again until next customer leaves
            button.SetActive(false);
            toggle.SetActive(false);
            game_data.can_next2 = false;
        }
    }

    private float speed = 5f;
    public IEnumerator Pickup(GameObject customer) {
        // if customer recieves bowl, sparkles + leaves
        sparkles.SetActive(true);
        yield return new WaitForSeconds(3f);
        sparkles.SetActive(false);

        while (customer.transform.position.x > -11) {
            customer.transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }

        // deactivate off screen
        customer.SetActive(false); 

        home.SetActive(true);
        game_data.once = true;
        game_data.constructed_orders--;

        // next button on if customers left
        if (game_data.ordered_customers != 0) {
            game_data.can_next2 = true;
            button.SetActive(true);
            toggle.SetActive(true);
        }

        // reset isFirstClick2
        stat_data.isFirstClick2 = true;

        // post to database
        user.order_given_ts2 = game_data.timer;
        RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);
    }
}
