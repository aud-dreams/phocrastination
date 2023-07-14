using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number : MonoBehaviour
{
    public game_data game_data;
    private SpriteRenderer number_sprite;
    private Dictionary<int, Sprite> numbers;
    private List<int> numbers_keys;

    [SerializeField]
    private List<Sprite> numbers_values;

    void Start()
    {
        number_sprite = GetComponent<SpriteRenderer>();
        numbers = new Dictionary<int, Sprite>();

        // initialize dict
        numbers_keys = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        for (int i = 0; i < numbers_keys.Count; i++) {
            numbers.Add(numbers_keys[i], numbers_values[i]);
        }
    }

    void Update()
    {
        if (gameObject.CompareTag("Serving")) {
            // customers in line
            number_sprite.sprite = GetNumber(game_data.current_customers);
        } else if (gameObject.CompareTag("Crafting")) {
            // orders placed
            number_sprite.sprite = GetNumber(game_data.orders);
        } else if (gameObject.CompareTag("Dishes")) {
            // dirty bowls
            number_sprite.sprite = GetNumber(game_data.dirty_bowls);
        }
    }

    private Sprite GetNumber(int key) {
        Sprite sprite = null;
        numbers.TryGetValue(key, out sprite);
        return sprite;
    }
}
