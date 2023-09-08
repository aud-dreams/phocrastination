using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager_transition : MonoBehaviour
{
    public GameObject[] text, toggles;
    public Animator crossfade;
    public string scene;
    public game_data game_data;
    public float proximityThreshold;
    public GameObject manager, player;

    void Update()
    {
        float distance = Vector3.Distance(manager.transform.position, player.transform.position);

        if (game_data.transition)
        {
            foreach (GameObject toggle in toggles)
            {
                toggle.SetActive(false);
            }
        }

        if (game_data.transition && game_data.transition_counter == 0)
        {
            // exclamation
            text[0].SetActive(true);
        }

        if (game_data.transition && distance <= proximityThreshold)
        {
            if (game_data.transition_counter == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f);

                    if (hit.collider != null)
                    {
                        game_data.transition_counter++;
                    }
                }
            }
            else if (game_data.transition_counter == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f);

                    if (hit.collider != null)
                    {
                        if (game_data.round_type == 1)
                        {
                            // good job on day1
                            text[0].SetActive(false);
                            text[1].SetActive(true);
                        }
                        else if (game_data.round_type == 2)
                        {
                            // good job on day2
                            text[0].SetActive(false);
                            text[2].SetActive(true);
                        }

                        game_data.transition_counter++;
                        StartCoroutine(Wait());
                    }
                }
            }
            else if (game_data.transition_counter == 2 && game_data.next_text1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f);

                    if (hit.collider != null)
                    {
                        // see you tomorrow
                        text[1].SetActive(false);
                        text[2].SetActive(false);
                        text[3].SetActive(true);
                        StartCoroutine(Wait2());
                        StartCoroutine(LoadScene());
                    }
                }
            }
        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        if (game_data.next_text1 == false)
        {
            game_data.next_text1 = true;
        }
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(3f);
    }

    IEnumerator LoadScene()
    {
        crossfade.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);

        if (game_data.round_type == 1)
        {
            game_data.Day2 = true;
            game_data.first_day2_help = true;
            game_data.transition = false;
        }
        else if (game_data.round_type == 2)
        {
            game_data.Day3 = true;
            game_data.first_day3_help = true;
            game_data.transition = false;
        }
    }
}
