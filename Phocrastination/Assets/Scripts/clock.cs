using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
    public game_data game_data;
    private SpriteRenderer clock_sprite;
    private Dictionary<string, Sprite> hours;
    private Dictionary<int, Sprite> numbers;
    private List<string> hours_keys;
    private List<int> numbers_keys;

    [SerializeField]
    private List<Sprite> hours_values, numbers_values;

    void Start()
    {
        clock_sprite = GetComponent<SpriteRenderer>();
        hours = new Dictionary<string, Sprite>();
        numbers = new Dictionary<int, Sprite>();

        // initialize dict
        hours_keys = new List<string>() { "8am", "10am", "12pm", "2pm", "4pm", "6pm" };
        numbers_keys = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        for (int i = 0; i < hours_keys.Count; i++) {
            hours.Add(hours_keys[i], hours_values[i]);
        }

        for (int i = 0; i < numbers_keys.Count; i++) {
            numbers.Add(numbers_keys[i], numbers_values[i]);
        }
    }

    void Update()
    {
        if (game_data.timer < 60) {
            clock_sprite.sprite = GetHour("8am");
        } else if (game_data.timer < 120) {
            clock_sprite.sprite = GetHour("10am");
        } else if (game_data.timer < 180) {
            clock_sprite.sprite = GetHour("12pm");
        } else if (game_data.timer < 240) {
            clock_sprite.sprite = GetHour("2pm");
        } else if (game_data.timer < 300) {
            clock_sprite.sprite = GetHour("4pm");
        } else {
            clock_sprite.sprite = GetHour("6pm");
        }
    }

    private Sprite GetHour(string key) {
        Sprite sprite = null;
        hours.TryGetValue(key, out sprite);
        return sprite;
    }
}
