using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public bool gameInProgress;
    public double timer;
    public game_data game_data;

    void Start()
    {
        gameInProgress = true;
        game_data.menu_on = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (gameInProgress == false) {
            //endGame condition
        }
        
    }

    void dayConfig() {
        // reset state vars

        // switch between days
    }


    // log at start of day, end of day, enter & end scene, interacting w objects
}
