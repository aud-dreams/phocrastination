using UnityEngine;
using System;
using Proyecto26;

public class generate_id : MonoBehaviour
{
    public game_data game_data;
    Counter UserCount;

    void Start()
    {
        GetNumberOfUsers();
    }

    private void GetNumberOfUsers()
    {
        RestClient.Get("https://phocrastination-user-default-rtdb.firebaseio.com/test.json").Then(response =>
        {
            Debug.Log(response.ToString());

            // // create Counter instance
            // UserCount = new Counter(response.user_count);
            // UserCount.add();
            // game_data.userID = UserCount.user_count;

            // // increment and update database
            // RestClient.Put("https://phocrastination-user-default-rtdb.firebaseio.com/test.json", UserCount);
            // Debug.Log(game_data.userID);
        });
    }

    public class Counter
    {
        public int user_count { get; set; }

        public Counter()
        {
        }

        public Counter(int initial)
        {
            user_count = initial;
        }

        public void add()
        {
            user_count++;
        }
    }
}