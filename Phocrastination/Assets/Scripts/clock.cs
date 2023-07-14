using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
    public game_data game_data;
    private SpriteRenderer clock_sprite;
    private Dictionary<string, Sprite> hours;
    private List<string> hours_keys;

    [SerializeField]
    private List<Sprite> hours_values;

    void Start()
    {
        clock_sprite = GetComponent<SpriteRenderer>();
        hours = new Dictionary<string, Sprite>();

        // initialize dict
        hours_keys = new List<string>() { "8am", "10am", "12pm", "2pm", "4pm", "6pm" };
        for (int i = 0; i < hours_keys.Count; i++) {
            hours.Add(hours_keys[i], hours_values[i]);
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
