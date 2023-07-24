using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowl_pickup : MonoBehaviour
{
    public game_data game_data;
    Vector3 mousePositionOffset;
    public BoxCollider2D bowl;
    private SpriteRenderer render;
    public GameObject button, toggle, sparkles;

    private void Start() {
        bowl = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private Vector3 GetMouseWorldPosition() {
        // capture mouse position & return WorldPoint
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown() {
        // capture mouse offset
        mousePositionOffset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag() {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private void OnTriggerEnter2D(Collider2D customer) {
        if (customer.CompareTag("collider")) {
            // first customer in line leaves
            StartCoroutine(Pickup(game_data.ordered_line[0]));
        }
    }

    private float speed = 5f;
    public IEnumerator Pickup(GameObject customer) {
        // if customer recieves bowl, sparkles + leaves
        sparkles.SetActive(true);
        yield return new WaitForSeconds(3f);
        sparkles.SetActive(false);
        render.enabled = false;

        while (customer.transform.position.x > -11) {
            customer.transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }

        // deactivate off screen
        customer.SetActive(false); 

        game_data.can_next = false;

        // next button on if customers left
        if (game_data.ordered_line.Count != 0) {
            game_data.can_next = true;
            button.SetActive(true);
            toggle.GetComponent<Renderer>().enabled = true;
        }

        game_data.ordered_line.RemoveAt(0);
        game_data.ordered_customers--;
    }
}
