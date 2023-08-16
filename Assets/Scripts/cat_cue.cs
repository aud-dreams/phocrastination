using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class cat_cue : MonoBehaviour
{
    public game_data game_data;
    public stat_data stat_data;
    public AudioSource src;
    public AudioClip cue;

    user_log user = new user_log();

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Cat_Music");

        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        src.clip = cue;
    }

    void Update()
    {
        if (!game_data.cue_once)
        {
            if (game_data.timer > 330)      // 5.5 mins
            {
                src.Play();
                game_data.cue_once = true;

                user.game_status = game_data.round_type;
                stat_data.cat_cue = game_data.timer;
                user.cat_cue_ts1 = game_data.timer;
                user.cat_cue_ts2 = user.cat_cue_ts1 + 5; // + 5 seconds
                RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
            }
        }

        if (!game_data.cue_twice)
        {
            if (game_data.timer > 150)     // 2.5 mins
            {
                src.Play();
                game_data.cue_twice = true;

                user.game_status = game_data.round_type;
                stat_data.cat_cue = game_data.timer;
                user.cat_cue_ts1 = game_data.timer;
                user.cat_cue_ts2 = user.cat_cue_ts1 + 5; // + 5 seconds
                RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
            }
        }
    }
}
