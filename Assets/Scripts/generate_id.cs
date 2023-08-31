using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Proyecto26;

[System.Serializable]
public class UserData
{
    public Dictionary<string, UserDataInstance> users;
}

[System.Serializable]
public class UserDataInstance
{
    public double bowl_created_ts1;
    public double bowl_created_ts2;
    public int bowl_washed_rem;
    public int bowl_washed_tot;
    public double bowl_washed_ts1;
    public double bowl_washed_ts2;
    public double cat_cue_ts1;
    public double cat_cue_ts2;
    public double cat_scene_ts1;
    public double cat_scene_ts2;
    public int color_switch;
    public int distractability_bool;
    public int game_status;
    public double global_timer;
    public int order_collected_rem;
    public int order_collected_tot;
    public double order_collected_ts1;
    public double order_collected_ts2;
    public int order_given_rem;
    public int order_given_tot;
    public double order_given_ts1;
    public double order_given_ts2;
    public float ratio_hit;
    public int redo;
    public double total_time_drawing;
}

public class generate_id : MonoBehaviour
{
    public game_data game_data;

    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(generateUserID());
        Debug.Log("After");
    }

    IEnumerator generateUserID()
    {
        RestClient.Get(game_data.db_url).Then(response =>
        {
            if (!string.IsNullOrEmpty(response.Text))
            {
                UserData jsonData = JsonUtility.FromJson<UserData>(response.Text);

                int instanceCount = jsonData.users.Count;
                int userID = instanceCount + 1;

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
