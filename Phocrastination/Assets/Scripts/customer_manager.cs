using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Proyecto26;

public class customer_manager : MonoBehaviour
{
    public game_data game_data;
    float offset = 1f;
    public GameObject boy_customer, girl_customer, toggle, button, home;
    private GameObject current;
    private SpriteRenderer toggle_render;
    user_log user = new user_log();

    void Start()
    {
        Vector3 position = new Vector3(3f, 3.04f, 0f);
        System.Random random = new System.Random();

        // reset customers_line
        game_data.customers_line.Clear();

        for (int i = 0; i < game_data.current_customers; i++)
        {
            // randomize current customer gender
            if (random.Next(2) == 1)
            {
                current = boy_customer;
            }
            else
            {
                current = girl_customer;
            }

            // set layer so customers are overlapping properly
            current.GetComponent<Renderer>().sortingOrder = game_data.current_customers - i;

            Vector3 newPosition = new Vector3(position.x + (i * offset), position.y, position.z);
            GameObject newCustomer = Instantiate(current, newPosition, Quaternion.identity);

            game_data.customers_line.Add(newCustomer);
        }

        boy_customer.SetActive(false);
        girl_customer.SetActive(false);
        Shadow();

        button.SetActive(false);
        toggle.GetComponent<Renderer>().enabled = false;

        // first customer in list leaves
        if (game_data.current_customers != 0)
        {
            StartCoroutine(Order(game_data.customers_line[0]));
            game_data.customers_line.RemoveAt(0);
            game_data.current_customers--;

            // check if last customer
            if (game_data.current_customers == 0)
            {
                game_data.last = true;
            }
        }
    }

    private IEnumerator blink(GameObject toggle)
    {
        toggle_render = toggle.GetComponent<SpriteRenderer>();
        for (int i = 0; i < 5; i++)
        {
            toggle_render.enabled = true;
            yield return new WaitForSeconds(0.3f);
            toggle_render.enabled = false;
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void Shadow()
    {
        for (int i = 1; i < game_data.customers_line.Count; i++)
        {
            Renderer renderer2 = game_data.customers_line[i].GetComponent<SpriteRenderer>();
            float darkenAmount = 0.65f;
            Color dark = new Color(renderer2.material.color.r * darkenAmount, renderer2.material.color.g * darkenAmount, renderer2.material.color.b * darkenAmount, renderer2.material.color.a);
            renderer2.material.color = dark;
        }
    }

    public GameObject speech;
    private float speed = 5f;

    public IEnumerator Order(GameObject customer)
    {
        // wait 5 seconds for order
        speech.SetActive(true);
        yield return new WaitForSeconds(5f);
        speech.SetActive(false);

        while (customer.transform.position.x > -11)
        {
            customer.transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }

        // deactivate off screen
        customer.SetActive(false);

        game_data.can_next = false;
        game_data.last = false;
        if (game_data.customers_line.Count != 0)
        {
            game_data.can_next = true;
            button.SetActive(true);
            toggle.GetComponent<Renderer>().enabled = true;
        }

        // increment num of orders
        game_data.orders++;
        game_data.ordered_customers++;

        // if in tutorial, blink home
        if (game_data.tutorial)
        {
            game_data.tutorial_main = true;
            StartCoroutine(blink(home));
        }

        user.order_collected_ts = game_data.timer;
        RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);
    }
}
