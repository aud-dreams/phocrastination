using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class next_customer_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;
    public GameObject button, toggle, home;

    user_log user = new user_log();

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
    }

    private void OnMouseEnter() {
        if (game_data.can_next) {
            render.enabled = true;
        }
    }

    private void OnMouseExit() {
        render.enabled = false;
    }

    public void Lighten() {
        Renderer renderer2 = game_data.customers_line[0].GetComponent<SpriteRenderer>();
        float lightenAmount = 1.53f;
        Color light = new Color(renderer2.material.color.r * lightenAmount, renderer2.material.color.g * lightenAmount, renderer2.material.color.b * lightenAmount, renderer2.material.color.a);
        renderer2.material.color = light;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
                if (game_data.can_next && !game_data.help) {
                    // all customers shift left & front customer turns active & light
                    foreach (GameObject customer in game_data.customers_line) {
                        customer.transform.position += new Vector3(-1f, 0f, 0f);
                    }
                    Lighten();
                    game_data.customers_line[0].SetActive(true);
                    StartCoroutine(Order(game_data.customers_line[0]));
                    game_data.customers_line.RemoveAt(0);
                    game_data.current_customers--;

                    // once button clicked, deactivate button again until next customer leaves
                    game_data.can_next = false;
                    button.SetActive(false);
                    toggle.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }

    public GameObject speech;
    public float speed = 5f;

    public IEnumerator Order(GameObject customer) {
        // wait 5 seconds for order
        speech.SetActive(true);
        yield return new WaitForSeconds(5f);
        speech.SetActive(false);

        while (customer.transform.position.x > -11) {
            customer.transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }

        // deactivate off screen
        customer.SetActive(false); 
        
        game_data.can_next = false;
        if (game_data.customers_line.Count != 0) {
            game_data.can_next = true;
            button.SetActive(true);
            toggle.GetComponent<Renderer>().enabled = true;
        }

        // increment num of orders & ordered_customers
        game_data.orders++;
        game_data.ordered_customers++;

        user.order_collected_ts = game_data.timer;
        RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);
    }
}
