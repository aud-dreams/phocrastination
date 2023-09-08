using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numbers2 : MonoBehaviour
{
    public game_data game_data;
    public GameObject number1, number2, number3;
    private SpriteRenderer render1, render2, render3;
    private Dictionary<int, Sprite> numbers;
    private List<int> numbers_keys;
    private int id;

    [SerializeField]
    private List<Sprite> numbers_values;

    void Start()
    {
        render1 = number1.GetComponent<SpriteRenderer>();
        render2 = number2.GetComponent<SpriteRenderer>();
        render3 = number3.GetComponent<SpriteRenderer>();
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
        // userID
        id = int.Parse(game_data.userID.Substring(6));

        if (id <= 9)      // single digits = 1 sprite
        {
            render1.sprite = GetNumber(id);
            render2.sprite = null;
            render3.sprite = null;
        }
        else if (id <= 99)    // double digits = 2 sprites
        {
            render1.sprite = GetNumber(id / 10);
            render2.sprite = GetNumber(id % 10);
            render3.sprite = null;
        }
        else
        {
            render1.sprite = GetNumber(id / 100);
            render2.sprite = GetNumber((id % 100) / 10);
            render3.sprite = GetNumber((id % 100) % 10);
        }
    }

    private Sprite GetNumber(int key)
    {
        Sprite sprite = null;
        numbers.TryGetValue(key, out sprite);
        return sprite;
    }
}
