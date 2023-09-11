using UnityEngine;
using System;
using Proyecto26;

public class generate_id : MonoBehaviour
{
    public game_data game_data;
    user_log user = new user_log();

    void Start()
    {
        //PostInitial();
        GetUserID();
    }

    private void GetUserID()
    {
        RestClient.Get<user_log>(game_data.db_url + "0.json").Then(callback =>
        {
            // take current player_count and increment
            game_data.userID = "player" + (callback.player_count + 1).ToString();

            // PUT (replace) player_count of player 0
            user.player_count = callback.player_count + 1;
            RestClient.Put(game_data.db_url + "0.json", user);

            user.tutorial_started = true;
            RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
        });
    }

    // private void PostInitial()
    // {
    //     user.player_count = 0;
    //     RestClient.Put(game_data.db_url + "0.json", user);
    // }
}