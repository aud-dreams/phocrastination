using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    public game_data game_data;
    public GameObject[] manager_text, station_text, toggles;
    public GameObject manager, player;
    public float proximityThreshold;
    private SpriteRenderer toggle_render;

    void Start()
    {
        tutorialConfig();
    }


    void tutorialConfig()
    {
        // create tutorial sequence
        if (game_data.tutorial)
        {
            foreach (GameObject text in station_text)
            {
                text.SetActive(true);
            }
            foreach (GameObject text in manager_text)
            {
                text.SetActive(false);
            }
            foreach (GameObject toggle in toggles)
            {
                toggle.SetActive(false);
            }
            if (game_data.tutorial_counter == 0)
            {
                // hello there
                manager_text[game_data.tutorial_counter].SetActive(true);
                game_data.tutorial_counter++;
            }
        }

    }
    private IEnumerator blink(GameObject toggle)
    {
        toggle_render = toggle.GetComponent<SpriteRenderer>();
        for (int i = 0; i < 6; i++)
        {
            toggle_render.enabled = true;
            yield return new WaitForSeconds(0.3f);
            toggle_render.enabled = false;
            yield return new WaitForSeconds(0.3f);
        }
        game_data.blink = false;
    }

    private void Update()
    {
        // wait for interact with manager
        float distance = Vector3.Distance(manager.transform.position, player.transform.position);

        if (distance <= proximityThreshold)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (game_data.tutorial_counter == 1)
                {
                    // take an order
                    manager_text[game_data.tutorial_counter - 1].SetActive(false);
                    manager_text[game_data.tutorial_counter].SetActive(true);

                    // restrict toggles
                    for (int i = 0; i < 5; i++)
                    {
                        if (i == game_data.tutorial_counter - 1)
                        {
                            toggles[i].SetActive(true);
                        }
                        else
                        {
                            toggles[i].SetActive(false);
                        }
                    }

                    // blink serving toggle
                    game_data.blink = true;
                    StartCoroutine(blink(toggles[game_data.tutorial_counter - 1]));

                    game_data.tutorial_counter++;
                }
                else if (game_data.tutorial_counter == 2 && game_data.take_order_done)
                {
                    // make the order
                    manager_text[game_data.tutorial_counter - 1].SetActive(false);
                    manager_text[game_data.tutorial_counter].SetActive(true);

                    // restrict toggles
                    for (int i = 0; i < 5; i++)
                    {
                        if (i == game_data.tutorial_counter - 1)
                        {
                            toggles[i].SetActive(true);
                        }
                        else
                        {
                            toggles[i].SetActive(false);
                        }
                    }

                    // blink crafting toggle
                    game_data.blink = true;
                    StartCoroutine(blink(toggles[game_data.tutorial_counter - 1]));

                    game_data.tutorial_counter++;
                }
                else if (game_data.tutorial_counter == 3 && game_data.make_order_done)
                {
                    // drop off the order
                    manager_text[game_data.tutorial_counter - 1].SetActive(false);
                    manager_text[game_data.tutorial_counter].SetActive(true);

                    // restrict toggles
                    for (int i = 0; i < 5; i++)
                    {
                        if (i == game_data.tutorial_counter - 1)
                        {
                            toggles[i].SetActive(true);
                        }
                        else
                        {
                            toggles[i].SetActive(false);
                        }
                    }

                    // blink pickup toggle
                    game_data.blink = true;
                    StartCoroutine(blink(toggles[game_data.tutorial_counter - 1]));

                    game_data.tutorial_counter++;
                }
                else if (game_data.tutorial_counter == 4 && game_data.drop_order_done)
                {
                    // wash some dishes
                    manager_text[game_data.tutorial_counter - 1].SetActive(false);
                    manager_text[game_data.tutorial_counter].SetActive(true);

                    // restrict toggles
                    for (int i = 0; i < 5; i++)
                    {
                        if (i == game_data.tutorial_counter - 1)
                        {
                            toggles[i].SetActive(true);
                        }
                        else
                        {
                            toggles[i].SetActive(false);
                        }
                    }

                    // blink dishes toggle
                    game_data.blink = true;
                    StartCoroutine(blink(toggles[game_data.tutorial_counter - 1]));

                    game_data.tutorial_counter++;
                }
                else if (game_data.tutorial_counter == 5 && game_data.wash_dishes_done)
                {
                    // pet the cat
                    manager_text[game_data.tutorial_counter - 1].SetActive(false);
                    manager_text[game_data.tutorial_counter].SetActive(true);

                    // restrict toggles
                    for (int i = 0; i < 5; i++)
                    {
                        if (i == game_data.tutorial_counter - 1)
                        {
                            toggles[i].SetActive(true);
                        }
                        else
                        {
                            toggles[i].SetActive(false);
                        }
                    }

                    // blink cat toggle
                    game_data.blink = true;
                    StartCoroutine(blink(toggles[game_data.tutorial_counter - 1]));

                    game_data.tutorial_counter++;
                }
                else if (game_data.tutorial_counter == 6 && game_data.pet_cat_done)
                {
                    manager_text[game_data.tutorial_counter - 1].SetActive(false);
                    game_data.tutorial = false;
                }
            }
        }
    }
}
