using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class customer_manager2 : MonoBehaviour
{
    public game_data game_data;
    float offset = 1f;
    public GameObject boy_customer, girl_customer, toggle, button;
    private GameObject current;
    
    void Start() {
        Vector3 position = new Vector3(3f, 3.04f, 0f);
        System.Random random = new System.Random();

        // reset customers_line
        game_data.ordered_line.Clear();

        for (int i = 0; i < game_data.ordered_customers; i++) {
            // randomize current customer gender
            if (random.Next(2) == 1) {
                current = boy_customer;
            } else {
                current = girl_customer;
            }

            // set layer so customers are overlapping properly
            current.GetComponent<Renderer>().sortingOrder = game_data.ordered_customers - i;

            Vector3 newPosition = new Vector3(position.x + (i * offset), position.y, position.z);
            GameObject newCustomer = Instantiate(current, newPosition, Quaternion.identity);

            game_data.ordered_line.Add(newCustomer);
        }
        
        boy_customer.SetActive(false);
        girl_customer.SetActive(false);
        Shadow();

        button.SetActive(false);
        toggle.GetComponent<Renderer>().enabled = false;
    }

    public void Shadow() {
        for (int i = 1; i < game_data.ordered_line.Count; i++) {
            Renderer renderer2 = game_data.ordered_line[i].GetComponent<SpriteRenderer>();
            float darkenAmount = 0.65f;
            Color dark = new Color(renderer2.material.color.r * darkenAmount, renderer2.material.color.g * darkenAmount, renderer2.material.color.b * darkenAmount, renderer2.material.color.a);
            renderer2.material.color = dark;
        }
    }
}
