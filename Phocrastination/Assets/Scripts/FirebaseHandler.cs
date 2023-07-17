using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.UI;

public class FirebaseHandler : MonoBehaviour
{
    user_log user = new user_log();
    public game_data game_data;
    
    void Start()
    {

    }

    public void PostToDatabase()
    {
        RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);
    }
    
    void Update()
    {

    }
}