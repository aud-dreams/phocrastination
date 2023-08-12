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
        if (game_data.day3_counter == 2)
        {
            manager.SetActive(false);
        }
    }

    void Update()
    {
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
                        text[game_data.day3_counter].SetActive(true);
                        text[game_data.day3_counter + 1].SetActive(false);
                        text[game_data.day3_counter + 2].SetActive(false);
                        game_data.day3_counter++;
                        StartCoroutine(Wait());
                    }
                }
                else if (game_data.day3_counter == 1 && game_data.next_text1)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        // today is up to you
                        text[game_data.day3_counter - 1].SetActive(false);
                        text[game_data.day3_counter].SetActive(true);
                        text[game_data.day3_counter + 1].SetActive(false);
                        game_data.day3_counter++;
                        StartCoroutine(Wait());
                    }
                }
                else if (game_data.day3_counter == 2 && game_data.next_text2)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        // feel free to do anything you desire
                        text[game_data.day3_counter - 2].SetActive(false);
                        text[game_data.day3_counter - 1].SetActive(false);
                        text[game_data.day3_counter].SetActive(true);
                        StartCoroutine(managerLeave());
                    }
                }
            }
        }
    }

    private float speed = 0.09f;

    IEnumerator managerLeave()
    {
        yield return new WaitForSeconds(3f);
        text[game_data.day3_counter].SetActive(false);

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
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
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