using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class generate_id : MonoBehaviour
{
    private string user_id;
    public game_data game_data;

    void Start()
    {
        generateUserID();
    }

    private void generateUserID()
    {
        string deviceID = Guid.NewGuid().ToString();
        game_data.userID = deviceID;
    }

    void Update()
    {
        
    }
}
