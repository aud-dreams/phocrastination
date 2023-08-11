using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public game_data game_data;
    public Animator crossfade;
    public string scene;
    IEnumerator LoadScene()
    {
        crossfade.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    void Update()
    {
        if (game_data.allow_timer && !game_data.tutorial)
        {
            game_data.timer += Time.deltaTime;
        }

        if (game_data.timer > 420 && game_data.round_type == 1)      // Day1 over
        {
            game_data.Day2 = true;
            StartCoroutine(LoadScene());
        }
        else if (game_data.timer > 420 && game_data.round_type == 2)      // Day2 over
        {
            game_data.Day3 = true;
            StartCoroutine(LoadScene());
        }
        else if (game_data.timer > 420 && game_data.round_type == 3)      // Day3 over
        {
            Application.Quit();
        }

        // decrement cat bar once cat scene first clicked on
        if (!game_data.first_cat_help && game_data.outside_catscene && game_data.progress_scale.x > 0)
        {
            game_data.progress_position = game_data.progress_position - new Vector3(0.0000099999f, 0f, 0f);
            game_data.progress_scale = game_data.progress_scale - new Vector3(0.00001f, 0f, 0f);
        }
    }
}
