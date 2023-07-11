using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer_manager : MonoBehaviour
{
    public game_data game_data;
    float offset = 1f;
    public GameObject current, toggle, button, home;
    
    void Start() {
        Vector3 position = new Vector3(3f, 3.04f, 0f); 
        Renderer renderer1 = current.GetComponent<Renderer>();

        // reset customers_line
        game_data.customers_line.Clear();

        for (int i = 0; i < game_data.current_customers; i++) {
            renderer1.sortingOrder = game_data.current_customers - i;

            Vector3 newPosition = new Vector3(position.x + (i * offset), position.y, position.z);
            GameObject newCustomer = Instantiate(current, newPosition, Quaternion.identity);

            game_data.customers_line.Add(newCustomer);
        }
        
        current.SetActive(false);
        Shadow();

        button.SetActive(false);
        toggle.GetComponent<Renderer>().enabled = false;

        // first customer in list leaves
        if (game_data.current_customers != 0) {
            StartCoroutine(Order(game_data.customers_line[0]));
            game_data.customers_line.RemoveAt(0);
            game_data.current_customers--;
        }
    }

    public void Shadow() {
        for (int i = 1; i < game_data.customers_line.Count; i++) {
            Renderer renderer2 = game_data.customers_line[i].GetComponent<SpriteRenderer>();
            float darkenAmount = 0.65f;
            Color dark = new Color(renderer2.material.color.r * darkenAmount, renderer2.material.color.g * darkenAmount, renderer2.material.color.b * darkenAmount, renderer2.material.color.a);
            renderer2.material.color = dark;
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
    }
}
