using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Proyecto26;

public class generate_id : MonoBehaviour
{
    public game_data game_data;

    void Start()
    {
        StartCoroutine(generateUserID());
    }

    IEnumerator generateUserID()
    {
        RestClient.Get(game_data.db_url).Then(response =>
        {
            if (!string.IsNullOrEmpty(response.Text))
            {
                int rowCount = response.Text.Split('\n').Length;
                int userID = rowCount + 1;

                game_data.userID = userID;
                Debug.Log($"Generated User ID: {userID}");
            }
        });

        yield return null;
    }

    void Update()
    {
        
    }
}
