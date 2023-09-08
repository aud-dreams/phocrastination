using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number : MonoBehaviour
{
    public game_data game_data;
    public GameObject number1, number2;
    private SpriteRenderer render1, render2;
    private Dictionary<int, Sprite> numbers;
    private List<int> numbers_keys;

    [SerializeField]
    private List<Sprite> numbers_values;

    void Start()
    {
        render1 = number1.GetComponent<SpriteRenderer>();
        render2 = number2.GetComponent<SpriteRenderer>();
        numbers = new Dictionary<int, Sprite>();

        // initialize dict
        numbers_keys = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        for (int i = 0; i < numbers_keys.Count; i++)
        {
            numbers.Add(numbers_keys[i], numbers_values[i]);
        }
    }

    void Update()
    {
        if (gameObject.CompareTag("Serving"))
        {
            // customers in line
            if (game_data.current_customers <= 9)   // single digits = 1 sprite
            {
                render1.sprite = GetNumber(game_data.current_customers);
                render2.sprite = null;
            }
            else    // double digits = 2 sprites side by side
            {
                render1.sprite = GetNumber(game_data.current_customers / 10);
                render2.sprite = GetNumber(game_data.current_customers % 10);
            }
        }
        else if (gameObject.CompareTag("Crafting"))
        {
            // orders placed
            if (game_data.orders <= 9)
            {
                render1.sprite = GetNumber(game_data.orders);
                render2.sprite = null;
            }
            else
            {
                render1.sprite = GetNumber(game_data.orders / 10);
                render2.sprite = GetNumber(game_data.orders % 10);
            }
        }
        else if (gameObject.CompareTag("Dishes"))
        {
            // dirty bowls
            if (game_data.dirty_bowls <= 9)
            {
                render1.sprite = GetNumber(game_data.dirty_bowls);
                render2.sprite = null;
            }
            else
            {
                render1.sprite = GetNumber(game_data.dirty_bowls / 10);
                render2.sprite = GetNumber(game_data.dirty_bowls % 10);
            }
        }
        else if (gameObject.CompareTag("Pickup"))
        {
            // ordered customers in line
            if (game_data.ordered_customers <= 9)
            {
                render1.sprite = GetNumber(game_data.ordered_customers);
                render2.sprite = null;
            }
            else
            {
                render1.sprite = GetNumber(game_data.ordered_customers / 10);
                render2.sprite = GetNumber(game_data.ordered_customers % 10);
            }
        }
    }

    private Sprite GetNumber(int key)
    {
        Sprite sprite = null;
        numbers.TryGetValue(key, out sprite);
        return sprite;
    }
}
