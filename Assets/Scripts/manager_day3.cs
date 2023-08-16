using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager_day3 : MonoBehaviour
{
    public game_data game_data;
    public GameObject manager, player;
    public GameObject[] text, toggles;
    private SpriteRenderer manager_render;
    public Sprite right_manager;
    public float proximityThreshold;

    void Start()
    {
        manager_render = manager.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (game_data.day3_counter == 0 && game_data.round_type == 3 && !game_data.first_day3_help)
        {
            text[game_data.day3_counter].SetActive(true);

        }

        if (game_data.round_type == 3)
        {
            // constraints
            foreach (GameObject toggle in toggles)
            {
                toggle.SetActive(false);
            }

            // wait for interact with manager
            float distance = Vector3.Distance(manager.transform.position, player.transform.position);

            if (distance <= proximityThreshold)
            {
                if (game_data.day3_counter == 0)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        // good job its the last day
                        text[0].SetActive(false);
                        text[1].SetActive(true);
                        text[2].SetActive(false);
                        text[3].SetActive(false);
                        game_data.day3_counter++;
                        StartCoroutine(Wait());
                    }
                }
                else if (game_data.day3_counter == 1 && game_data.next_text1)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        // your coworker is taking over for today
                        text[0].SetActive(false);
                        text[1].SetActive(false);
                        text[2].SetActive(true);
                        text[3].SetActive(false);
                        game_data.day3_counter++;
                        StartCoroutine(Wait());
                    }
                }
                else if (game_data.day3_counter == 2 && game_data.next_text2)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        // feel free to do anything you desire
                        text[0].SetActive(false);
                        text[1].SetActive(false);
                        text[2].SetActive(false);
                        text[3].SetActive(true);
                        StartCoroutine(managerLeave());
                    }
                }
            }
            else if (game_data.day3_counter == 3)
            {
                manager.SetActive(false);
            }
        }
    }

    private float speed = 0.12f;

    IEnumerator managerLeave()
    {
        yield return new WaitForSeconds(3f);
        text[3].SetActive(false);

        // switch to right sprite
        manager_render.sprite = right_manager;

        // move right and disappear at door
        while (manager.transform.position.x < 7.77)
        {
            manager.transform.Translate(Vector3.right * speed * Time.deltaTime);
            yield return null;
        }

        manager.SetActive(false);

        game_data.allow_timer = true;
        foreach (GameObject toggle in toggles)
        {
            toggle.SetActive(true);
        }

        game_data.day3_counter++;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        if (game_data.next_text1 == false)
        {
            game_data.next_text1 = true;
        }
        else if (game_data.next_text2 == false)
        {
            game_data.next_text2 = true;
        }
    }
}