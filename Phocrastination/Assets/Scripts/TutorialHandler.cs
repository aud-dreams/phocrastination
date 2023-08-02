using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    public game_data game_data;
    public GameObject[] manager_text, station_text, toggles;
    public GameObject manager, player;
    public float proximityThreshold;

    void Start()
    {
        tutorialConfig();
    }


    void tutorialConfig() {
        // create tutorial sequence
        if (game_data.tutorial) {
            foreach (GameObject text in station_text) {
                text.SetActive(true);
            }
            foreach (GameObject text in manager_text) {
                text.SetActive(false);
            }
            if (game_data.tutorial_counter == 0) {
                manager_text[game_data.tutorial_counter].SetActive(true);
                game_data.tutorial_counter++;
            }
        }
        
    } 

    private void Update() {
        // wait for interact with manager
        float distance = Vector3.Distance(manager.transform.position, player.transform.position);

        if (distance <= proximityThreshold) {
            if (Input.GetKey(KeyCode.Space)) {
                if (game_data.tutorial_counter == 1) {
                    manager_text[game_data.tutorial_counter-1].SetActive(false);
                    manager_text[game_data.tutorial_counter].SetActive(true);
                    game_data.tutorial_counter++;
                    Debug.Log(game_data.tutorial_counter);
                } else if (game_data.tutorial_counter == 2 && game_data.take_order_done) {
                    manager_text[game_data.tutorial_counter-1].SetActive(false);
                    manager_text[game_data.tutorial_counter].SetActive(true);
                    game_data.tutorial_counter++;
                    Debug.Log(game_data.tutorial_counter);
                } else if (game_data.tutorial_counter == 3 && game_data.make_order_done) {
                    manager_text[game_data.tutorial_counter-1].SetActive(false);
                    manager_text[game_data.tutorial_counter].SetActive(true);
                    game_data.tutorial_counter++;
                    Debug.Log(game_data.tutorial_counter);
                } else if (game_data.tutorial_counter == 4 && game_data.drop_order_done) {
                    manager_text[game_data.tutorial_counter-1].SetActive(false);
                    manager_text[game_data.tutorial_counter].SetActive(true);
                    game_data.tutorial_counter++;
                    Debug.Log(game_data.tutorial_counter);
                } else if (game_data.tutorial_counter == 5 && game_data.wash_dishes_done) {
                    manager_text[game_data.tutorial_counter-1].SetActive(false);
                    manager_text[game_data.tutorial_counter].SetActive(true);
                    game_data.tutorial_counter++;
                    Debug.Log(game_data.tutorial_counter);
                } else if (game_data.tutorial_counter == 6 && game_data.pet_cat_done) {
                    manager_text[game_data.tutorial_counter-1].SetActive(false);
                    game_data.tutorial = false;
                }
            }
        }
    }
}
