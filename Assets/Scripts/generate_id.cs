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
        GetNumberOfUsers();
    }

    private void GetNumberOfUsers()
    {
        RestClient.Get<user_log>(game_data.db_url + "0.json").Then(callback =>
        {
            // take current player_count and increment
            Debug.Log(callback.player_count);
            game_data.userID = callback.player_count + 1;
            Debug.Log(game_data.userID);

            // PUT (replace) player_count of player 0
            user.player_count = game_data.userID;
            RestClient.Put(game_data.db_url + "0.json", user);
        });
    }

    // private void PostInitial()
    // {
    //     user.player_count = 0;
    //     RestClient.Put(game_data.db_url + "0.json", user);
    // }
}